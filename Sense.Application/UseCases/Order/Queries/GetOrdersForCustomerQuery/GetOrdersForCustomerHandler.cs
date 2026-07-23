using Sense.Application.RequestFeatures;
using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OrderDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.CustomerDTOs;

namespace Sense.Application.UseCases.Order.Queries.GetOrdersForCustomerQuery
{
    public class GetOrdersForCustomerHandler : IRequestHandler<GetOrdersForCustomerQuery, ResponseResult<IEnumerable<OrderDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetOrdersForCustomerHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<OrderDto>>> Handle(GetOrdersForCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<IEnumerable<OrderDto>>.GetResult(ResultCodeStatus.NotFound, "Customer not found.");

            var orders = await _repositoryManager.Order.GetAllOrdersAsync(new OrderParameters());
            var customerOrders = orders.Where(x => x.CustomerId == customer.Id)
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
                                       .ToList();


            return ResponseResult<IEnumerable<OrderDto>>.GetResult(ResultCodeStatus.Success, customerOrders, "The data reterived successfully.");

        }
    }
}
