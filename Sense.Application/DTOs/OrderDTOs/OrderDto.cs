using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? OrderMemo { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderDate { get; set; }
        public string? OrderTime { get; set; }
        public decimal? TotalOrderNet { get; set; }
        public decimal? DeliveryFee { get; set; }

        public CustomerDto? Customer { get; set; }
        public AddressDto? Address { get; set; }
    }

}
