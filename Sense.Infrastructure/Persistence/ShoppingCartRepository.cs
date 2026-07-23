using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.ShoppingCartRepositories
{
	public class ShoppingCartRepository : RepositoryBase<ShoppingCartTbl>, IShoppingCartRepository
	{
		public ShoppingCartRepository(SenseDbContext context) : base(context)
		{
		}

		public void CreateShoppingCart(ShoppingCartTbl ShoppingCart)
			=> Create(ShoppingCart);


		public void DeleteShoppingCart(ShoppingCartTbl ShoppingCart)
			=> Delete(ShoppingCart);


		public async Task<IEnumerable<ShoppingCartTbl>> GetAllShoppingCartsAsync()
			=> await FindAll().Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Items).ToListAsync();


		public async Task<ShoppingCartTbl> GetShoppingCartByCustomerIdAsync(int customerId)
			=> await FindByCondition(x => x.CustomerId == customerId).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Items).FirstOrDefaultAsync();

		public void UpdateShoppingCart(ShoppingCartTbl ShoppingCart)
			=> Update(ShoppingCart);

	}

}

