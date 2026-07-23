using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class CouponUsageTbl : BaseEntity
    {
        public int? CouponId { get; set; }
        public CouponTbl? Coupon { get; set; }

        public int? CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }
    }
}
