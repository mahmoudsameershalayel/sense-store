using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.FreeMaintenanceOfferDTOs
{
    public class FreeMaintenanceOfferForCreateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int RequiredAppointments { get; set; }
        public int FreePeriodInDays { get; set; }
    }
}
