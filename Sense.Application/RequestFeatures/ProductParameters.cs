using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public string? ProductName { get; set; } // Filter by product name
        public int? ProductCategoryId { get; set; } // Filter by product category
        public int? ProductBrandId { get; set; } // Filter by product brand
        public int? ProductModelId { get; set; } // Filter by product model
        public bool? IsSparePart { get; set; }
        public ProductStatus? Status { get; set; } // Filter by approval/visibility status
        public int? ProviderId { get; set; } // Filter by provider
    }
}