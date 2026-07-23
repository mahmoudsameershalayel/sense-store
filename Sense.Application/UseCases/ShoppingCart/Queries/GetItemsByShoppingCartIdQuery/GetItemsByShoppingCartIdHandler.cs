using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ShoppingCartDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ShoppingCart.Queries.GetItemsByShoppingCartIdQuery
{
	public class GetItemsByShoppingCartIdHandler : IRequestHandler<GetItemsByShoppingCartIdQuery, ResponseResult<IEnumerable<CartItemDto>>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetItemsByShoppingCartIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<IEnumerable<CartItemDto>>> Handle(GetItemsByShoppingCartIdQuery request, CancellationToken cancellationToken)
		{
			var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.UserId);
			if (customer is null)
				return ResponseResult<IEnumerable<CartItemDto>>.GetResult(ResultCodeStatus.NotFound, $"The User Not Found!!");

			var cart = await _repositoryManager.ShoppingCart.GetShoppingCartByCustomerIdAsync(customer.Id);
			if (cart is null)
				return ResponseResult<IEnumerable<CartItemDto>>.GetResult(ResultCodeStatus.NotFound, $"The Shopping Cart is empty!!");


			var cartItems = await _repositoryManager.CartItem.GetAllCartItemsByShoppingCartIdAsync(cart.Id);
			var dtos = _mapper.Map<IEnumerable<CartItemDto>>(cartItems);
			return ResponseResult<IEnumerable<CartItemDto>>.GetResult(ResultCodeStatus.Success, dtos, $"The Item for shopping Cart with id : {cart.Id} reterived successfully");

		}
	}
}
