using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.MaintenanceRecordDTOs
{
    public class MaintenanceRecordForCreateDto
    {
        public DateTime? StartDate { get; set; }
        public int AppointmentId { get; set; }
        public int SupervisorId { get; set; }
    }

}
