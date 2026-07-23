using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.OrderDTOs;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsForStatisticsQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Queries.GetAllOrdersForStatisticsQuery
{
    public class GetAllOrdersForStatisticsHandler : IRequestHandler<GetAllOrdersForStatisticsQuery, ResponseResult<IEnumerable<OrderDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllOrdersForStatisticsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<OrderDto>>> Handle(GetAllOrdersForStatisticsQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _repositoryManager.Order.GetAllOrdersAsync();
            var orders = allOrders
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
            var allDtos = _mapper.Map<List<OrderDto>>(orders);
            return ResponseResult<IEnumerable<OrderDto>>.GetResult(ResultCodeStatus.Success, allDtos, "The data retrieved successfully.");
        }
    }
}
