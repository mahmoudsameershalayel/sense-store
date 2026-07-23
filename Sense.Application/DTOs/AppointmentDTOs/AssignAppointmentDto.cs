using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.AppointmentDTOs
{
    public class AssignAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public int? BranchId { get; set; }
        public int? SupervisorId { get; set; }
    }
}
