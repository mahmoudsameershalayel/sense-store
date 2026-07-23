using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.AppointmentDTOs
{
    public class RejectAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string? RejectReason { get; set; }
    }
}
