using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.PointsDTOs
{
    public class RedeemPointsDto
    {
        public int PointsToRedeem { get; set; }
        public int? OrderId { get; set; }
        public int? MaintenanceRecordId { get; set; }
        public string? CurrentUserId { get; set; }
    }
}