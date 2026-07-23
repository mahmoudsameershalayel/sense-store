using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ShoppingCart.Commands.UpdateItemShoppingCartCommand
{
    public class UpdateItemShoppingCartHandler : IRequestHandler<UpdateItemShoppingCartCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateItemShoppingCartHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(UpdateItemShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.UserId);
            if (customer is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The User Not Found!!");

            var cart = await _repositoryManager.ShoppingCart.GetShoppingCartByCustomerIdAsync(customer.Id);
            if (cart is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"The Shopping Cart is not exist!!");


            var shoppingCartItems = await _repositoryManager.CartItem.GetAllCartItemsByShoppingCartIdAsync(cart.Id);
            var cartExist = shoppingCartItems.Where(x => x.ProductId == request.Dto.ProductId).FirstOrDefault();
            if (cartExist is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"The cart item is not exist!!");

             cartExist.ProductQuantity = request.Dto.ProductQuantity;
            _repositoryManager.CartItem.UpdateCartItem(cartExist);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"Error occured while saving entity!!");

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The quantity updated successfully");

        }
    }
}
