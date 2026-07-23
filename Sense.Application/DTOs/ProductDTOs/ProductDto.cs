using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ProductDTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? OfferDisVal { get; set; }
        public int QuantityAvaliable { get; set; }
        public decimal? TotalSales { get; set; }
        public string? ImageURL { get; set; }

        public bool IsSparePart { get; set; }
        public ProductStatus Status { get; set; }
        public BrandDto? Brand { get; set; }
        public ModelDto? Model { get; set; }

        public CategoryDto? Category { get; set; }

        public int? ProviderId { get; set; }
        public string? ProviderName { get; set; }


        
       


}
}
