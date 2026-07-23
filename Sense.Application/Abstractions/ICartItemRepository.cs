using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
	public interface ICartItemRepository
	{
		Task<IEnumerable<CartItemTbl>> GetAllCartItemsByShoppingCartIdAsync(int shoppinCartId);
		Task<CartItemTbl> GetItemByShoppingCartAndItemId(int shoppingCartId, int productId);
		void CreateCartItem(CartItemTbl CartItem);
		void UpdateCartItem(CartItemTbl CartItem);
		void DeleteCartItem(CartItemTbl CartItem);
		void ClearAllItemsFromShoppingCart(int shoppingCartId);
	}
}
