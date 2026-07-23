using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.OrderDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Queries.GetOrderByIdQuery
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, ResponseResult<OrderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetOrderByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        //This handle to get order details by Amin OR Customer
        public async Task<ResponseResult<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repositoryManager.Order.GetOrderById(request.OrderId);
            if (order is null)
                return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.NotFound, $"There is no order with id : {request.OrderId}!!");

            if (!string.IsNullOrEmpty(request.CurrentUserId))
            {
                var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
                bool isCustomer = customer != null;
                if (isCustomer && order.CustomerId != customer.Id)
                    return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.Forbiden, "You do not have permission to access this order.");
            }


            var dto = _mapper.Map<OrderDto>(order);
            return ResponseResult<OrderDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");

        }
    }
}
