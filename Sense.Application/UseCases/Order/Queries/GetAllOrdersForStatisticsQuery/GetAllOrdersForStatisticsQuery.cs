using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.OrderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Queries.GetAllOrdersForStatisticsQuery
{
    public class GetAllOrdersForStatisticsQuery : IRequest<ResponseResult<IEnumerable<OrderDto>>>
    {
    }
}