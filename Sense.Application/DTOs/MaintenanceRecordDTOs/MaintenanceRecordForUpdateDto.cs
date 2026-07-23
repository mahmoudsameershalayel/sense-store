using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.MaintenanceRecordDTOs
{
    public class MaintenanceRecordForUpdateDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal? TotalCost { get; set; }

        public int? SupervisorId { get; set; }
    }

}
