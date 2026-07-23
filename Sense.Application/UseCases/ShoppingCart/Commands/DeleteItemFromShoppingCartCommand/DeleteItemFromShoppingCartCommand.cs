using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ShoppingCart.Commands.DeleteItemFromShoppingCartCommand
{
	public class DeleteItemFromShoppingCartCommand : IRequest<ResponseResult<bool>>
	{
		public string UserId { get; set; }
		public int ProductId { get; set; }

	}
}
