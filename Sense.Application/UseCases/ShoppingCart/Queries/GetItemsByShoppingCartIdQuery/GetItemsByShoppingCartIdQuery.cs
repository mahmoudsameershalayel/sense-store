using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ShoppingCartDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ShoppingCart.Queries.GetItemsByShoppingCartIdQuery
{
	public class GetItemsByShoppingCartIdQuery : IRequest<ResponseResult<IEnumerable<CartItemDto>>>
	{
		public string UserId { get; set; }

	}

}
