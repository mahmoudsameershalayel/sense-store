using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.RequestFeatures
{
    public class MaintenanceRecordParameters : RequestParameters
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal? MinTotalCost { get; set; }
        public decimal? MaxTotalCost { get; set; }

        public int? SupervisorId { get; set; }
        public int? AppointmentId { get; set; }

        public string? SortBy { get; set; } // e.g., "StartDate", "TotalCost"
        public bool SortDescending { get; set; } = false;
    }
}
