using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CouponDTOs
{
    public class CouponForUpdateDto
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public OfferDiscountType DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public int PerUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
