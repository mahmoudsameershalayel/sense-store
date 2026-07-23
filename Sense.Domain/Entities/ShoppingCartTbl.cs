using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
	public class ShoppingCartTbl  : BaseEntity
	{
		public int CustomerId { get; set; }
		public CustomerTbl Customer { get; set; }
		public ICollection<CartItemTbl> Items { get; set; }	 = new List<CartItemTbl>();	
	}
}
