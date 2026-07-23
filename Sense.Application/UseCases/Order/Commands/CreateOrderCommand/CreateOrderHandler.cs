using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OrderDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Commands.CreateOrderCommand
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, ResponseResult<OrderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;
        public CreateOrderHandler(IRepositoryManager repositoryManager, IMapper mapper, UserManager<ApplicationUserTbl> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }


        private async Task CheckInventoryAvailability(ShoppingCartTbl shoppingCart)
        {
            foreach (var item in shoppingCart.Items)
            {
                var product = await _repositoryManager.Product.GetProductByIdAsync(item.ProductId);

                if (product is null)
                    throw new Exception($"المنتج غير موجود!");

                if (item.ProductQuantity > product.QuantityAvaliable)
                    throw new Exception($"الكمية غير متوفرة للمنتج: {product.Name}");
            }
        }
        private async Task<long> GenerateInvoiceNoAsync(int orderId)
        {
            var invoiceNo = 100000L + orderId;
            while (await _repositoryManager.Invoice.GetInvoiceByIdAsync(invoiceNo) is not null)
                invoiceNo++;

            return invoiceNo;
        }

        private async Task CreateOrderInvoice(OrderTbl order, decimal orderNetValue)
        {
            var invoice = new InvoiceTbl
            {
                InvoiceNo = await GenerateInvoiceNoAsync(order.Id),
                InvoiceAmount = orderNetValue,
                InvoiceType = InvoiceType.StoreOrderInvoice,
                CreatedAt = DateTime.UtcNow,
                OrderId = order.Id
            };

            order.IsHaveSaleInv = true;
            order.SaleInvNo = invoice.InvoiceNo;
            _repositoryManager.Order.UpdateOrderAll(order);
            _repositoryManager.Invoice.CreateInvoice(invoice);
        }

        public async Task<ResponseResult<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.NotFound, $"المستخدم غير موجود!");
            var user = await _userManager.FindByIdAsync(customer.ApplicationUserId);
            if (!request.ShoppingCart.Items.Any())
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.BadRequest, $"لا يمكن إتمام الشراء , لا يوجد منتجات في السلة!!");

            try
            {
                await CheckInventoryAvailability(request.ShoppingCart);
            }
            catch (Exception ex)
            {
                return ResponseResult<OrderDto>.GetResult(
                    ResultCodeStatus.BadRequest,
                    ex.Message
                );
            }

            var orderAll = new OrderTbl
            {
                CustomerId = customer.Id,
                AddressId = request.Dto.AddressId,
                OrderDate = DateTime.UtcNow,
                OrderMemo = request.Dto.OrderMemo,
                PhoneNumber = request.Dto.PhoneNumber,
                OrderStatus = OrderStatus.Pending,
                PaymentMethod = request.Dto.PaymentMethod,
                PaymentStatus = PaymentStatus.Pending,
                DeliveryFee = request.Dto.DeliveryFee
            };

            _repositoryManager.Order.CreateOrderAll(orderAll);
            await _repositoryManager.SaveAsync();

            //Check if order has a discount
            if (!string.IsNullOrEmpty(request.Dto.CouponCode))
            {
                // Get the coupon
                var coupon = await _repositoryManager.Coupon.GetCouponAsync(request.Dto.CouponCode);

                if (coupon is null)
                    return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.NotFound, $"الكوبون {request.Dto.CouponCode} غير موجود!");

                // Check validity dates
                if (coupon.StartDate > DateTime.UtcNow || coupon.EndDate < DateTime.UtcNow)
                    return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.BadRequest, $"الكوبون {coupon.CouponCode} غير فعال حالياً!");

                // Check usage per user
                var userUsageCount = coupon.CouponUsages.Count(x => x.CustomerId == customer.Id);
                if (userUsageCount >= coupon.PerUser)
                    return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.BadRequest, $"لقد تجاوزت الحد المسموح من استخدام الكوبون : {coupon.CouponCode}!!");

                // Calculate discount
                decimal discount = 0;
                decimal total = request.ShoppingCart.Items.Sum(x => (x.ProductPrice ?? 0) * x.ProductQuantity);

                switch (coupon.DiscountType)
                {
                    case OfferDiscountType.Fixed:
                        discount = coupon.DiscountAmount;
                        break;

                    case OfferDiscountType.Percentage:
                        discount = total * coupon.DiscountAmount / 100m;
                        break;
                }

                // Apply discount
                orderAll.OrderTotalOfferDisValue = discount;

                // Track usage
                var couponUsage = new CouponUsageTbl
                {
                    CouponId = coupon.Id,
                    CustomerId = customer.Id
                };
                _repositoryManager.CouponUsage.CreateCouponUsage(couponUsage);

                await _repositoryManager.SaveAsync();
            }


            var orderDetailsList = new List<OrderDetailsTbl>();

            foreach (var item in request.ShoppingCart.Items)
            {
                var product = await _repositoryManager.Product.GetProductByIdAsync(item.Id);
                var orderDetails = new OrderDetailsTbl
                {
                    OrderId = orderAll.Id,
                    ProductId = item.ProductId,
                    Product = product,
                    CustomerId = customer.Id,
                    ProductPrice = item.ProductPrice,
                    ProductAmount = item.ProductQuantity,
                    ProductOfferDisValue = item.ProductOfferDisVal,
                    ProductNetPrice = item.ProductPrice - item.ProductOfferDisVal,
                };
                orderDetailsList.Add(orderDetails);
            }

            //calculate the order Vals
            decimal OrderTotal = orderDetailsList?.Sum(i => (i.ProductPrice ?? 0) * (i.ProductAmount ?? 0)) ?? 0;
            decimal OrderTotalVatValue = orderDetailsList?.Sum(i => (i.ProductPrice ?? 0) * (i.ProductAmount ?? 0) * (i.Product?.VatPrcent ?? 0) / 100) ?? 0;
            decimal OrderTotalTaxValue = orderDetailsList?.Sum(i => (i.ProductPrice ?? 0) * (i.ProductAmount ?? 0) * (i.Product?.TaxPrcent ?? 0) / 100) ?? 0;
            decimal DelivertFee = orderAll.DeliveryFee == null ? 0 : (decimal)orderAll.DeliveryFee;
            decimal discountOrder = orderAll.OrderTotalOfferDisValue ?? 0;
            decimal OrderNetValue = OrderTotal + DelivertFee - discountOrder;
            orderAll.OrderNetValue = (double)OrderNetValue;
            var wallet = await _repositoryManager.Wallet.GetWalletsByCustomerId(customer.Id);
            if (wallet is null)
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.NotFound, "لا يوجد لديك محفظة , عليك مراسلة الدعم الفني لحل المشكلة");
            if (request.Dto.PaymentMethod == PaymentMethod.Wallet)
            {

                if (wallet.Balance < (double)OrderNetValue)
                    return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.BadRequest, "لا يوجد لديك رصيد كافي في المحفظة!!");

                wallet.Balance -= (double)OrderNetValue;
                orderAll.PaymentStatus = PaymentStatus.Completed;

                _repositoryManager.Order.UpdateOrderAll(orderAll);
                _repositoryManager.Wallet.UpdateWallet(wallet);
                await _repositoryManager.SaveAsync();
            }

            _repositoryManager.OrderDetails.CreateListOfOrderDetails(orderDetailsList);
            await CreateOrderInvoice(orderAll, OrderNetValue);
            await _repositoryManager.SaveAsync();


            var cashBackOffers = await _repositoryManager.CashbackOffer.GetAllOffersAsync();
            var applicableCashBackOffers = cashBackOffers.Where(x =>
                x.IsActive == true &&
                x.IsApplyOnStore == true &&
                x.IsDeleted == false &&
                x.StartDate <= DateTime.UtcNow &&
                x.EndDate >= DateTime.UtcNow).ToList();

            if (applicableCashBackOffers.Any())
            {

                CashbackOfferTbl bestCashBackOffer = null;
                decimal bestCashBackValue = 0;

                foreach (var offer in applicableCashBackOffers)
                {
                    decimal potentialCashBackVal = 0;
                    switch (offer.CashbackType)
                    {
                        case CashbackType.Percentage:
                            potentialCashBackVal = (offer.CashbackVal / 100) * OrderNetValue;
                            break;
                        case CashbackType.Fixed:
                            potentialCashBackVal = offer.CashbackVal;
                            break;
                    }

                    // Select the offer that gives the highest cashback value
                    if (potentialCashBackVal > bestCashBackValue)
                    {
                        bestCashBackValue = potentialCashBackVal;
                        bestCashBackOffer = offer;
                    }
                }

                if (bestCashBackOffer is not null && bestCashBackValue > 0)
                {
                    decimal cashBackVal = bestCashBackValue;

                    // Apply the cashback based on return type
                    switch (bestCashBackOffer.ReturnType)
                    {
                        case ReturnType.Points:
                            if (user.MyPoints == null)
                                user.MyPoints = 0;
                            user.MyPoints += (int)cashBackVal;
                            await _userManager.UpdateAsync(user);

                            // Create points transaction record for cashback
                            var pointsTransaction = new PointsTransactionTbl
                            {
                                CustomerId = customer.Id,
                                PointsRedeemed = -(int)cashBackVal, // Negative because it's adding points (earning)
                                AmountDeducted = 0, // No amount deducted since we're earning points
                                PointsToSARRate = 1, // Default rate for earning points
                                OrderId = orderAll.Id,
                                CreatedAt = DateTime.UtcNow,
                                Details = $"كاش باك نقاط من الطلب رقم {orderAll.Id} - عرض: {bestCashBackOffer.Id}"
                            };
                            _repositoryManager.PointsTransaction.CreatePointsTransaction(pointsTransaction);
                            break;

                        case ReturnType.CashOnWallet:
                            wallet.Balance += (double)cashBackVal;
                            _repositoryManager.Wallet.UpdateWallet(wallet);
                            var transaction = new TransactionTbl
                            {
                                CustomerId = customer.Id,
                                WalletId = wallet.Id,
                                TransactionType = TransactionType.Cashback,
                                Amount = cashBackVal,
                                CreatedAt = DateTime.UtcNow,
                                Details = $"استرداد نقدي من الطلب رقم {orderAll.Id} - عرض: {bestCashBackOffer.Id}"
                            };
                            _repositoryManager.Transaction.CreateTransaction(transaction);
                            break;
                    }
                    var cashbackUsage = new CashbackOfferUsageTbl
                    {
                        CashbackOfferId = bestCashBackOffer.Id,
                        CustomerId = customer.Id,
                        OrderId = orderAll.Id,
                        CashbackVal = cashBackVal,
                        CreatedAt = DateTime.UtcNow
                    };
                    _repositoryManager.CashbackOfferUsage.CreateOfferUsage(cashbackUsage);
                }
            }

            await _repositoryManager.SaveAsync();


            var orderDto = _mapper.Map<OrderDto>(orderAll);
            return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.Created, orderDto, $"تم إنشاء الطلب بنجاح برقم: {orderAll.Id}");
        }
    }
}
