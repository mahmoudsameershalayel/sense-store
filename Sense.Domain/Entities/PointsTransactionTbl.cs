using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class PointsTransactionTbl : BaseEntity
    {
        public int CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }
        
        public int PointsRedeemed { get; set; }
        public decimal AmountDeducted { get; set; }
        public decimal PointsToSARRate { get; set; } // Rate used at the time of redemption
        
        // Track which order or maintenance record this was used for
        public int? OrderId { get; set; }
        public OrderTbl? Order { get; set; }
        
        public int? MaintenanceRecordId { get; set; }
        public MaintenanceRecordTbl? MaintenanceRecord { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Details { get; set; }
    }
}