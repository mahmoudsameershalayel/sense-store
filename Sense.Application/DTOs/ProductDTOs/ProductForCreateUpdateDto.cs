using Sense.Domain.Enums;
using Sense.Application.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ProductDTOs
{
    public class ProductForCreateUpdateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvaliable { get; set; }
        public bool IsSparePart { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? ProviderId { get; set; }
	}
}
