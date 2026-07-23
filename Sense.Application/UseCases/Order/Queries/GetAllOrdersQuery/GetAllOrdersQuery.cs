using Sense.Application.RequestFeatures;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.OrderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Queries.GetAllOrdersQuery
{
    public class GetAllOrdersQuery : IRequest<ResponseResult<PagedList<OrderDto>>>
    {
        public string? CurrentUserId { get; set; }
        public required OrderParameters OrderParameters { get; set; }
    }
}
