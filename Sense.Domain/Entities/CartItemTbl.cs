using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
	public class CartItemTbl : BaseEntity
	{	
        public int ProductQuantity { get; set; }
		public decimal? ProductPrice { get; set; }
		public decimal? ProductOfferDisVal { get; set; }
		public decimal? ProductNetPrice { get; set; }

		public int ShoppingCartId { get; set; }
		public ShoppingCartTbl? ShoppingCart { get; set; }

        public int ProductId { get; set; }
        public ProductTbl? Product { get; set; }
    }
}
