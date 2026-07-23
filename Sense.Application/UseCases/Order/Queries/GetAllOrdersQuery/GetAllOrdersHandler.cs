using Sense.Application.RequestFeatures;
using Sense.Application;
using Sense.Application.DTOs.OrderDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.CustomerDTOs;

namespace Sense.Application.UseCases.Order.Queries.GetAllOrdersQuery
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, ResponseResult<PagedList<OrderDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllOrdersHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<PagedList<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.CurrentUserId))
            {
                var allItemsWithMetaData = await _repositoryManager.Order.GetAllOrdersAsync(request.OrderParameters);
                var allOrders = allItemsWithMetaData
                     .Select(order => new OrderDto
                     {
                         Id = order.Id,
                         OrderMemo = order.OrderMemo,
                         PaymentMethod = order.PaymentMethod?.ToString(),
                         PaymentStatus = order.PaymentStatus?.ToString(),
                         OrderStatus = order.OrderStatus?.ToString(),
                         OrderDate = order.OrderDate?.ToString("yyyy-MM-dd"),
                         OrderTime = order.OrderDate?.ToString("HH:mm"),
                         TotalOrderNet = order.OrderDetails.Sum(d =>
                             d.ProductPrice),
                         Customer = _mapper.Map<CustomerDto>(order.Customer),
                         Address = _mapper.Map<AddressDto>(order.Address)
                     })
                     .ToList();// Map the filtered items to AppointmentDto


                // Add metadata to the response
                var allPagedResult = new PagedList<OrderDto>(allOrders, allItemsWithMetaData.MetaData.TotalCount, allItemsWithMetaData.MetaData.CurrentPage, allItemsWithMetaData.MetaData.PageSize);

                // Return the response with metadata and data
                return ResponseResult<PagedList<OrderDto>>.GetResult(ResultCodeStatus.Success, allPagedResult, "The data retrieved successfully.");
            }
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<PagedList<OrderDto>>.GetResult(ResultCodeStatus.NotFound, $"The User Not Found!!");

            var customerItemsWithMetaData = await _repositoryManager.Order.GetMyAllOrdersAsync(customer.Id , request.OrderParameters);

            var customerOrders = customerItemsWithMetaData
                             .Select(order =>
                             {
                                 var orderDetails = order.OrderDetails;
                                 var orderTotal = orderDetails.Sum(d =>
                                            (d.ProductPrice - (d.ProductOfferDisValue ?? 0)) * d.ProductAmount);
                                 var offerDiscountTotal = order.OrderTotalOfferDisValue ?? 0;
                                 var deliveryFee = order.DeliveryFee ?? 0;
                                 var netTotal = orderTotal + deliveryFee - offerDiscountTotal;

                             return new OrderDto
                             {
                                 Id = order.Id,
                                 OrderMemo = order.OrderMemo,
                                 PaymentMethod = order.PaymentMethod?.ToString(),
                                 PaymentStatus = order.PaymentStatus?.ToString(),
                                 OrderStatus = order.OrderStatus?.ToString(),
                                 OrderDate = order.OrderDate?.ToString("yyyy-MM-dd"),
                                 OrderTime = order.OrderDate?.ToString("HH:mm tt"),
                                 TotalOrderNet = netTotal,
                                 Customer = _mapper.Map<CustomerDto>(order.Customer),
                                 Address = _mapper.Map<AddressDto>(order.Address)
                             };
                             
        }).ToList();


            var pagedResult = new PagedList<OrderDto>(customerOrders, customerItemsWithMetaData.MetaData.TotalCount, customerItemsWithMetaData.MetaData.CurrentPage, customerItemsWithMetaData.MetaData.PageSize);

            return ResponseResult<PagedList<OrderDto>>.GetResult(ResultCodeStatus.Success, pagedResult, "The data retrieved successfully.");
        }
    }
}
