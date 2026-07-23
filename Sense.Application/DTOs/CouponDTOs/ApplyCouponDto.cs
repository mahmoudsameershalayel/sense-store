using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CouponDTOs
{
    public class ApplyCouponDto
    {
        public string CouponCode { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
