using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.MaintenanceRecordDTOs
{
    public class MaintenanceRecordDto
    {
        public int Id { get; set; }

        public string? StartDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndDate { get; set; }
        public string? EndTime { get; set; }
        public string Status { get; set; }

        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; } 

        public int SupervisorId { get; set; }
        public string? SupervisorName { get; set; }
    }

}
