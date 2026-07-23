using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ShoppingCart.Commands.ClearAllShoppingCartCommand
{
	public class ClearAllShoppingCartHandler : IRequestHandler<ClearAllShoppingCartCommand, ResponseResult<bool>>
	{
		private readonly IRepositoryManager _repositoryManager;
		public ClearAllShoppingCartHandler(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public async Task<ResponseResult<bool>> Handle(ClearAllShoppingCartCommand request, CancellationToken cancellationToken)
		{
			var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.UserId);
			if (customer is null)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The User Not Found!!");

			var cart = await _repositoryManager.ShoppingCart.GetShoppingCartByCustomerIdAsync(customer.Id);
			if (cart is null)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Shopping Cart is empty!!");


			_repositoryManager.CartItem.ClearAllItemsFromShoppingCart(cart.Id);


			int affectedRows = await _repositoryManager.SaveAsync();
			if (affectedRows == 0)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"Error occured while saving entity!!");

			return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Shopping Cart cleared successfully!!");

		}
	}
}
