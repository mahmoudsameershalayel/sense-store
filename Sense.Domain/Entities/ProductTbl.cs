using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class ProductTbl : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? OfferDisVal { get; set; }
        public int QuantityAvaliable { get; set; }
        public string? ImageURL { get; set; }
        public bool IsSparePart { get; set; }
        public decimal? VatPrcent { get; set; }
        public decimal? TaxPrcent { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Draft;

        public int CategoryId { get; set; }
        public CategoryTbl? Category { get; set; }

        public int? ProviderId { get; set; }
        public ProviderTbl? Provider { get; set; }

        public int? BrandId { get; set; }
        public BrandTbl? Brand { get; set; }

        public int? ModelId { get; set; }
        public ModelTbl? Model { get; set; }

        public ICollection<CartItemTbl> CartItems { get; set; } = new List<CartItemTbl>();
        public ICollection<InventoryTbl> Inventories { get; set; } = new List<InventoryTbl>();
    }
}
