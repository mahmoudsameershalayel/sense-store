using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.FreeMaintenanceOfferDTOs
{
    public class ActivateFreeMaintenanceOfferDto
    {
        public string CurrentUserId { get; set; }
        public int OfferId { get; set; }
    }
}
