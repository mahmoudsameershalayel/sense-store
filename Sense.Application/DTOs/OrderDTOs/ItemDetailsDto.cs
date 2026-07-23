using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.OrderDTOs
{
    public class ItemDetailsDto
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImage { get; set; }
        public decimal? ProductAmount { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductOfferDisValue { get; set; }
        public decimal? ProductTotalValue { get; set; }
        public decimal? VatPrcent { get; set; }
        public decimal? TaxPrcent { get; set; }
        public string? Memo { get; set; }
        public bool IsSparePart { get; set; }
        public string? ImageURL { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public string? ModelName { get; set; }


        // Calculated Properties
        public decimal ProductTotal => (ProductPrice ?? 0) * (ProductAmount ?? 0);

        public decimal TotalOfferDisValue => ProductOfferDisValue ?? 0;

        public decimal TotalVatValue => (ProductTotal - TotalOfferDisValue) * (VatPrcent ?? 0) / 100;

        public decimal TotalTaxValue => (ProductTotal - TotalOfferDisValue) * (TaxPrcent ?? 0) / 100;
        public decimal EznItemNetPrice =>
    ((ProductPrice ?? 0) - ((ProductOfferDisValue ?? 0) / (ProductAmount ?? 1)));

        public decimal EznNetValue => (ProductTotal - TotalOfferDisValue) + TotalVatValue + TotalTaxValue;
    }

}
