using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ShoppingCartDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ShoppingCart.Commands.UpdateItemShoppingCartCommand
{
    public class UpdateItemShoppingCartCommand : IRequest<ResponseResult<bool>>
    {
        public string UserId { get; set; }
        public CartItemForUpdateDto Dto { get; set; }

    }
}