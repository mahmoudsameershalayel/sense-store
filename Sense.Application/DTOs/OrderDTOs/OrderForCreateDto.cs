using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.OrderDTOs
{
    public class OrderForCreateDto
    {
        public int AddressId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OrderMemo { get; set; }
        public string? CouponCode { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public decimal? DeliveryFee { get; set; }
    }

}
