using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{

    public class OrderDetailsTbl : BaseEntity
    {
        public DateTime? OrderDate { get; set; }
        public string? CustomerDatabaseKey { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductAmount { get; set; }
        public decimal? ProductOfferDisValue { get; set; }
        public decimal? ProductNetPrice { get; set; }
        public string? Memo { get; set; }
        public bool? IsHaveSaleInv { get; set; }
        public long? SaleInvNo { get; set; }
        public bool? IsUpload { get; set; }
        public string? UploadUserId { get; set; }
        public string? UploadLoginNo { get; set; }
        public DateTime? UploadDateTtime { get; set; }
        public string? CouponCode { get; set; }

        public int OrderId { get; set; }
        public OrderTbl? Order { get; set; }

        public int ProductId { get; set; }
        public ProductTbl? Product { get; set; }


        public int? CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }

    }
}
