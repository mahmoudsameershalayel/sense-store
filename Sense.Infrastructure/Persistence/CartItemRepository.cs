using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.CartItemRepositories
{
	public class CartItemRepository : RepositoryBase<CartItemTbl>, ICartItemRepository
	{
		public CartItemRepository(SenseDbContext context) : base(context)
		{
		}

		public void ClearAllItemsFromShoppingCart(int shoppingCartId)
			=> ClearAll(x => x.ShoppingCartId == shoppingCartId);


		public void CreateCartItem(CartItemTbl CartItem)
			=> Create(CartItem);


		public void DeleteCartItem(CartItemTbl CartItem)
			=> Delete(CartItem);

		public async Task<IEnumerable<CartItemTbl>> GetAllCartItemsByShoppingCartIdAsync(int shoppingCartId)
			=> await FindByCondition(x => x.ShoppingCartId == shoppingCartId).Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.Product).ThenInclude(x => x.Brand).Include(x => x.ShoppingCart) 
																			 .Include(x => x.ShoppingCart).ThenInclude(x => x.Customer)
																			 .Include(x => x.ShoppingCart).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
																			 .ToListAsync();

		public async Task<CartItemTbl> GetItemByShoppingCartAndItemId(int shoppingCartId, int productId)
			 => await FindByCondition(x => x.ShoppingCartId == shoppingCartId && x.ProductId == productId).Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.Product).ThenInclude(x => x.Brand).Include(x => x.ShoppingCart)
																			 .Include(x => x.ShoppingCart).ThenInclude(x => x.Customer)
																			 .Include(x => x.ShoppingCart).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
																			 .FirstOrDefaultAsync();

		public void UpdateCartItem(CartItemTbl CartItem)
			=> Update(CartItem);

	}
}
