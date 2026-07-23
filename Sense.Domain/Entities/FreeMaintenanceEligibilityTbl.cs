using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class FreeMaintenanceEligibilityTbl  : BaseEntity
    {
        public bool? IsEligible { get; set; }
        public bool IsActivated { get; set; }
        public DateTime? ActivatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public int? CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }

        public int? FreeMaintenanceOfferId { get; set; }
        public FreeMaintenanceOfferTbl? FreeMaintenanceOffer { get; set; }
    }
}
