using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OrderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Queries.GetOrdersForCustomerQuery
{
    public class GetOrdersForCustomerQuery : IRequest<ResponseResult<IEnumerable<OrderDto>>>
    {
        public string? CurrentUserId { get; set; }
    }
}
