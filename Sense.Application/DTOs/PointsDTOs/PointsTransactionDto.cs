using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.PointsDTOs
{
    public class PointsTransactionDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PointsRedeemed { get; set; }
        public decimal AmountDeducted { get; set; }
        public decimal PointsToSARRate { get; set; }
        public int? OrderId { get; set; }
        public int? MaintenanceRecordId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Details { get; set; }
    }
}