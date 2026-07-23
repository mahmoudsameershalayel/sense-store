using Sense.Application.RequestFeatures;
using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OrderDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.UseCases.Order.Commands.CreateOrderAPICommand
{
    public class CreateOrderAPIHandler : IRequestHandler<CreateOrderAPICommand, ResponseResult<OrderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateOrderAPIHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }



        /*  private bool ValidateCoupon(CouponTbl coupon)
          {
              // Check if coupon is null or inactive
              if (coupon is null)
              {
                  return false;
              }

              // Check if coupon has expired
              var currentDate = DateTime.UtcNow;
              if (currentDate > coupon.StartDate && currentDate < coupon.EndDate)
              {
                  return false;
              }

              return true;
          } 

          private double ApplyCouponDiscount(double totalAmount, CouponTbl coupon)
          {

              // Validate coupon first
              if (!ValidateCoupon(coupon))
              {
                  return totalAmount; // If the coupon is invalid, return the original amount
              }

              double discount = 0;
              // Apply discount based on DiscountType
              switch (coupon.DiscountType)
              {
                  case DiscountType.FixedAmount:
                      discount = coupon.DiscountValue;
                      break;

                  case DiscountType.Percentage:
                      discount = totalAmount * (coupon.DiscountValue / 100);
                      break;

                  default:
                      throw new ArgumentOutOfRangeException();
              }

              return Math.Max(0, totalAmount - discount);

          }

          
        */


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

        public async Task<ResponseResult<OrderDto>> Handle(CreateOrderAPICommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.NotFound, $"The Customer Not Found!!");

            var address = await _repositoryManager.Address.GetAddressAsync(request.Dto.AddressId);
            if (address is null)
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.NotFound, $"The Address Not Found!!");

            var shoppingCart = await _repositoryManager.ShoppingCart.GetShoppingCartByCustomerIdAsync(customer.Id);

            if (shoppingCart is null)
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.BadRequest, $"The Shopping Cart is empty!!");


            var orderAll = new OrderTbl
            {
                CustomerId = customer.Id,
                AddressId = address.Id,
                OrderDate = DateTime.UtcNow,
                OrderMemo = request.Dto.OrderMemo,
                OrderStatus = OrderStatus.Pending,
                PaymentMethod = request.Dto.PaymentMethod,
                PaymentStatus = PaymentStatus.Pending,
                DeliveryFee = 0
            };
            _repositoryManager.Order.CreateOrderAll(orderAll);
            try
            {
                await _repositoryManager.SaveAsync();
            }
            catch (DbUpdateException dbEx)
            {
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.Failed,
                    $"DbUpdateException: {dbEx.Message} - Inner: {dbEx.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.Failed,
                    $"Exception: {ex.Message} - Inner: {ex.InnerException?.Message}");
            }
           /* if (request.Dto.CouponDisValue != 0)
            {
                var coupon = await _repositoryManager.Coupon.GetCouponAsync(request.Dto.CouponCode);
                if (coupon is null)
                    return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.NotFound, $"The coupon : {request.Dto.CouponCode} not found!!");
                var allCouponUsages = await _repositoryManager.CouponUsage.GetAllCouponUsagesAsync();
                var couponUsagesByUserCount = allCouponUsages.Where(x => x.CustomerId == customer.Id).Count();
                var couponUsage = new CouponUsageTbl { CouponId = coupon.Id, CustomerId = customer.Id };
                if (coupon.PerUser <= couponUsagesByUserCount)
                    return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.BadRequest, $"The user apply this coupon : {request.Dto.CouponCode} more than allowed times!!");
                _repositoryManager.CouponUsage.CreateCouponUsage(couponUsage);
                await _repositoryManager.SaveAsync();
            }  */
            var orderDetailsList = new List<OrderDetailsTbl>();
            foreach (var item in shoppingCart.Items)
            {
                var product = await _repositoryManager.Product.GetProductByIdAsync(item.ProductId);
                var orderDetails = new OrderDetailsTbl
                {
                    OrderId = orderAll.Id,
                    ProductId = item.ProductId,
                    CustomerId = customer.Id,
                    ProductPrice = item.ProductPrice,
                    ProductAmount = item.ProductQuantity,
                    ProductOfferDisValue = item.ProductOfferDisVal,
                    ProductNetPrice = item.ProductPrice - item.ProductOfferDisVal,
                    Product = product
                };
                orderDetailsList.Add(orderDetails);
            }

            //calculate the order Vals
            decimal OrderTotal = orderDetailsList?.Sum(i => (i.ProductPrice ?? 0) * (i.ProductAmount ?? 0)) ?? 0;
            decimal OrderTotalVatValue = orderDetailsList?.Sum(i => (i.ProductPrice ?? 0) * (i.ProductAmount ?? 0) * (i.Product?.VatPrcent ?? 0) / 100) ?? 0;
            decimal OrderTotalTaxValue = orderDetailsList?.Sum(i => (i.ProductPrice ?? 0) * (i.ProductAmount ?? 0) * (i.Product?.TaxPrcent ?? 0) / 100) ?? 0;
            decimal DelivertFee = orderAll.DeliveryFee == null ? 0 : (decimal)orderAll.DeliveryFee;
            decimal OrderNetValue = OrderTotal + DelivertFee - (orderAll.OrderTotalOfferDisValue ?? 0);
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

            //clear all shopping cart
            _repositoryManager.CartItem.ClearAllItemsFromShoppingCart(shoppingCart.Id);
            var cashBackOffers = await _repositoryManager.CashbackOffer.GetAllOffersAsync();
            var cashBackOffer = cashBackOffers.Where(x => x.IsActive == true && x.StartDate <= DateTime.UtcNow && x.EndDate >= DateTime.UtcNow).FirstOrDefault();
            if (cashBackOffer is not null)
            {
                decimal cashBackVal = 0;
                switch (cashBackOffer.CashbackType)
                {
                    case CashbackType.Percentage:
                        cashBackVal = (cashBackOffer.CashbackVal / 100) * OrderNetValue;
                        break;
                    case CashbackType.Fixed:
                        cashBackVal = cashBackOffer.CashbackVal;
                        break;
                }
                wallet.Balance += (double)cashBackVal;
                _repositoryManager.Wallet.UpdateWallet(wallet);
            }
            await _repositoryManager.SaveAsync();


            var orderDto = _mapper.Map<OrderDto>(orderAll);
            return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.Created, orderDto, $"The Order with Id : {orderAll.Id} created successfully");


        }
    }
}
