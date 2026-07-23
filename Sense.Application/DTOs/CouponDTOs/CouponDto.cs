using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CouponDTOs
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public int PerUser { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
