using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.CashbackOfferUsageDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.OrderDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Queries.GetOrderDetailsQuery
{
    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetailsQuery, ResponseResult<OrderDetailsDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetOrderDetailsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        //This handle to get order details by Amin OR Customer
        public async Task<ResponseResult<OrderDetailsDto>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _repositoryManager.Order.GetOrderById(request.OrderId);
            if (order is null)
                return ResponseResult<OrderDetailsDto>.GetResult(ResultCodeStatus.NotFound, $"There is no order with id : {request.OrderId}!!");

            if (!string.IsNullOrEmpty(request.CurrentUserId))
            {
                var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
                bool isCustomer = customer != null;
                if (isCustomer && order.CustomerId != customer.Id)
                    return ResponseResult<OrderDetailsDto>.GetResult(ResultCodeStatus.Forbiden, "You do not have permission to access this order.");
            }

            var itemDetails = new List<ItemDetailsDto>();
            foreach (var details in order.OrderDetails)
            {
                var detail = new ItemDetailsDto
                {
                    ProductId = details.Product.Id,
                    ProductName = details.Product.Name,
                    ProductDescription = details.Product.Description,
                    ProductImage = details.Product.ImageURL,
                    ProductPrice = details.ProductPrice,
                    ProductAmount = details.ProductAmount,
                    ProductOfferDisValue = details.ProductOfferDisValue,
                    VatPrcent = details.Product.VatPrcent,
                    TaxPrcent = details.Product.TaxPrcent,
                    Memo = details.Memo,
                    IsSparePart = details.Product.IsSparePart,
                    ImageURL = details.Product.ImageURL,
                    CategoryName = details.Product.Category?.Name,
                    BrandName = details.Product.Brand?.Name,
                    ModelName = details.Product.Model?.Name,
                };
                itemDetails.Add(detail);
            }

            // Map cashback usage data
            var cashbackUsages = new List<CashbackOfferUsageDto>();
            if (order.CashbackUsages != null && order.CashbackUsages.Any())
            {
                cashbackUsages = _mapper.Map<List<CashbackOfferUsageDto>>(order.CashbackUsages);
            }

            var customerDto = _mapper.Map<CustomerDto>(order.Customer);
            var addressDto = _mapper.Map<AddressDto>(order.Address);
            var orderDetails = new OrderDetailsDto
            {
                Id = order.Id,
                OrderStatus = order.OrderStatus.ToString(),
                PaymentMethod = order.PaymentMethod.ToString(),
                PaymentStatus = order.PaymentStatus.ToString(),
                OrderMemo = order.OrderMemo,
                PhoneNumber = !string.IsNullOrWhiteSpace(order.PhoneNumber) ? order.PhoneNumber : customerDto?.PhoneNumber,
                Customer = customerDto,
                Address = addressDto,
                ItemDetails = itemDetails,
                DeliveryFee = order.DeliveryFee ?? 0,
                OrderTotalOfferDisValue = order.OrderTotalOfferDisValue ?? 0,
                CashbackUsages = cashbackUsages
            };

            // Get points transaction if exists
            var pointsTransaction = await _repositoryManager.PointsTransaction.GetPointsTransactionByOrderIdAsync((int)order.Id);
            if (pointsTransaction != null)
            {
                orderDetails.PointsTransaction = _mapper.Map<DTOs.PointsDTOs.PointsTransactionDto>(pointsTransaction);
            }

            return ResponseResult<OrderDetailsDto>.GetResult(ResultCodeStatus.Success, orderDetails, "The data reterived successfully.");
        }
    }
}
