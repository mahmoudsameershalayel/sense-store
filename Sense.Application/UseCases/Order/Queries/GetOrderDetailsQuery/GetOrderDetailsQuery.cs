using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OrderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Queries.GetOrderDetailsQuery
{
    public class GetOrderDetailsQuery : IRequest<ResponseResult<OrderDetailsDto>>
    {
        public string? CurrentUserId { get; set; }
        public required int OrderId { get; set; }
    }
}
