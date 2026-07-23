using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class OrderTbl : BaseEntity
    {
        public double? OrderNetValue { get; set; }
        public string? OrderMemo { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal? OrderTipVal { get; set; }
        public bool? IsHaveSaleInv { get; set; }
        public long? SaleInvNo { get; set; }
        public bool? IsUpload { get; set; }
        public string? UploadUserId { get; set; }
        public string? UploadLoginNo { get; set; }
        public DateTime? UploadDateTtime { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OutForDeliveryTime { get; set; }
        public decimal? OrderTotalOfferDisValue { get; set; }
        public decimal? DeliveryFee { get; set; }


        public int? CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }



        public int? AddressId { get; set; }
        public AddressTbl? Address { get; set; }


        public ICollection<OrderDetailsTbl> OrderDetails { get; set; } = new List<OrderDetailsTbl>();
        public ICollection<CashbackOfferUsageTbl> CashbackUsages { get; set; } = new List<CashbackOfferUsageTbl>();
        public ICollection<InvoiceTbl> Invoices { get; set; } = new List<InvoiceTbl>();
    }

}
