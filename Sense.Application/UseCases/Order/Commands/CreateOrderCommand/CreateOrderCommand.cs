using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.OrderDTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommand : IRequest<ResponseResult<OrderDto>>
    {
        public required string CurrentUserId { get; set; }
        public ShoppingCartTbl? ShoppingCart { get; set; }
        public required OrderForCreateDto Dto { get; set; }

    }
}
