using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ShoppingCart.Commands.DeleteItemFromShoppingCartCommand
{
	public class DeleteItemFromShoppingCartHandler : IRequestHandler<DeleteItemFromShoppingCartCommand, ResponseResult<bool>>
	{
		private readonly IRepositoryManager _repositoryManager;
		public DeleteItemFromShoppingCartHandler(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public async Task<ResponseResult<bool>> Handle(DeleteItemFromShoppingCartCommand request, CancellationToken cancellationToken)
		{
			var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.UserId);
			if (customer is null)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The User Not Found!!");

			var cart = await _repositoryManager.ShoppingCart.GetShoppingCartByCustomerIdAsync(customer.Id);
			if (cart is null)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Shopping Cart is empty!!");


			var cartItem = await _repositoryManager.CartItem.GetItemByShoppingCartAndItemId(cart.Id, request.ProductId);
			if (cartItem is null)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Cart Item Not Found!!");

			_repositoryManager.CartItem.DeleteCartItem(cartItem);

			int affectedRows = await _repositoryManager.SaveAsync();
			if (affectedRows == 0)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"Error occured while saving entity!!");

			return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Cart Item Deleted from cart successfully!!");

		}
	}
}
