using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.RequestFeatures
{
    public class OrderParameters : RequestParameters
    {
        public string? SearchTerm { get; set; } // Optional search term for general search
        public DateTime? StartDate { get; set; } // Filter by start date
        public DateTime? EndDate { get; set; } // Filter by end date
        public int? Status { get; set; } // Filter by order status
        public int? CustomerId { get; set; } // Filter by customer (user) ID
        public bool IsHistory { get; set; } // Flag for history or current orders
        public bool IsActive { get; set; } // Flag for history or current orders
    }
}
