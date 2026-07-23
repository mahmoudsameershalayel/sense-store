using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class CouponTbl : BaseEntity
    {
        public string CouponCode { get; set; }
        public OfferDiscountType DiscountType{ get; set; }
        public decimal DiscountAmount { get; set; }
        public int PerUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<CouponUsageTbl> CouponUsages { get; set; } = new List<CouponUsageTbl>();
    }
}
