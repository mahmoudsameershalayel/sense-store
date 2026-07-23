using Sense.Domain.Enums;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.CashbackOfferUsageDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.PointsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.OrderDTOs
{
    public class OrderDetailsDto
    {
        public long Id { get; set; }
        public string? OrderMemo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public string? OrderStatus { get; set; }
        public CustomerDto? Customer { get; set; }
        public AddressDto? Address { get; set; }
        public decimal OrderTotalOfferDisValue { get; set; }
        public decimal DeliveryFee { get; set; }
        public List<ItemDetailsDto>? ItemDetails { get; set; }
        public ICollection<CashbackOfferUsageDto> CashbackUsages { get; set; } = new List<CashbackOfferUsageDto>();

        // Points discount information
        public PointsTransactionDto? PointsTransaction { get; set; }

        // Calculated value
        public decimal OrderTotal => ItemDetails?.Sum(i => i.ProductTotal) ?? 0;

        public decimal OrderTotalVatValue => ItemDetails?.Sum(i => i.TotalVatValue) ?? 0;

        public decimal OrderTotalTaxValue => ItemDetails?.Sum(i => i.TotalTaxValue) ?? 0;

        public decimal OrderNetValue => OrderTotal + DeliveryFee - OrderTotalOfferDisValue;

        public decimal TotalCashbackReceived => CashbackUsages.Sum(usage => usage.CashbackVal ?? 0);

        public decimal PointsDiscount => PointsTransaction?.AmountDeducted ?? 0;

        public decimal FinalTotalAfterPointsDiscount => OrderNetValue - PointsDiscount;
    }
}
