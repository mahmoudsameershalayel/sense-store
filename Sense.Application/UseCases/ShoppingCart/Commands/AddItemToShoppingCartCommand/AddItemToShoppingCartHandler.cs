using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;


namespace Sense.Application.UseCases.ShoppingCart.Commands.AddItemToShoppingCartCommand
{
	public class AddItemToShoppingCartHandler : IRequestHandler<AddItemToShoppingCartCommand, ResponseResult<bool>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		public AddItemToShoppingCartHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<ResponseResult<bool>> Handle(AddItemToShoppingCartCommand request, CancellationToken cancellationToken)
		{
			var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.UserId);
			if (customer is null)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The User Not Found!!");

			var cart = await _repositoryManager.ShoppingCart.GetShoppingCartByCustomerIdAsync(customer.Id);
			if (cart is null)
			{
				var shoppingCart = new ShoppingCartTbl
				{
					CreatedAt = DateTime.UtcNow,
					CustomerId = customer.Id,
				};
				_repositoryManager.ShoppingCart.CreateShoppingCart(shoppingCart);
				await _repositoryManager.SaveAsync();
			}
			var existingCart = await _repositoryManager.ShoppingCart.GetShoppingCartByCustomerIdAsync(customer.Id);
			var cartItem = _mapper.Map<CartItemTbl>(request.Dto);
			cartItem.ProductNetPrice = cartItem.ProductPrice - cartItem.ProductOfferDisVal;

            // 🧾 Check Stock Before Add
            var product = await _repositoryManager.Product.GetProductByIdAsync(cartItem.ProductId);
            if (product == null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "Product not found");

            if (product.QuantityAvaliable < cartItem.ProductQuantity) // Assuming Quantity is in Dto
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, "الكمية المطلوبة غير متوفرة في المخزون");

            var shoppingCartItems = await _repositoryManager.CartItem.GetAllCartItemsByShoppingCartIdAsync(existingCart.Id);
            var cartExist = shoppingCartItems.Where(x => x.ProductId == cartItem.ProductId).FirstOrDefault();
			if (cartExist is null)
			{
				cartItem.ShoppingCartId = existingCart.Id;
				_repositoryManager.CartItem.CreateCartItem(cartItem);
			}
			else
			{
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"The cart item is exist!!");
            }

            int affectedRows = await _repositoryManager.SaveAsync();
			if (affectedRows == 0)
				return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"Error occured while saving entity!!");

			return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Product Added to cart successfully");

		}
	}
}
