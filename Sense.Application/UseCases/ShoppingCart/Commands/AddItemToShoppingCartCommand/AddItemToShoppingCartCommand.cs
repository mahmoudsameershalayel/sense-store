using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ShoppingCartDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ShoppingCart.Commands.AddItemToShoppingCartCommand
{
	public class AddItemToShoppingCartCommand : IRequest<ResponseResult<bool>>
	{
		public string UserId { get; set; }
		public CartItemForCreateDto Dto { get; set; }

	}
}
