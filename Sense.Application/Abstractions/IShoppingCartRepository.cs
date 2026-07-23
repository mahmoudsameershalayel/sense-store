using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IShoppingCartRepository
	{
		Task<IEnumerable<ShoppingCartTbl>> GetAllShoppingCartsAsync();
		Task<ShoppingCartTbl> GetShoppingCartByCustomerIdAsync(int customerId);
		void CreateShoppingCart(ShoppingCartTbl ShoppingCart);
		void UpdateShoppingCart(ShoppingCartTbl ShoppingCart);
		void DeleteShoppingCart(ShoppingCartTbl ShoppingCart);
	}
}
