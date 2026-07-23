using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.FreeMaintenanceOfferDTOs
{
    public class FreeMaintenanceOfferDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public int RequiredAppointments { get; set; }
        public int FreePeriodInDays { get; set; }
        public bool IsActive { get; set; }
    }
}
