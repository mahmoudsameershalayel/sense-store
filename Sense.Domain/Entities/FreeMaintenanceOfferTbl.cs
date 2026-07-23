using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class FreeMaintenanceOfferTbl : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public int RequiredAppointments { get; set; }
        public int FreePeriodInDays { get; set; }
      
    }
}
