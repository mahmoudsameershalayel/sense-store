using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OrderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Commands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusCommand : IRequest<ResponseResult<bool>>
    {
        public OrderForUpdateStatusDto Dto { get; set; }
    }
}
