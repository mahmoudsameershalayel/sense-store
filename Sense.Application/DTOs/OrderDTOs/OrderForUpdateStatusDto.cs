using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.OrderDTOs
{
    public class OrderForUpdateStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
