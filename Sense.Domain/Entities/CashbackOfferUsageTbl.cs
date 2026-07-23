using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class CashbackOfferUsageTbl : BaseEntity
    {
        public decimal? CashbackVal { get; set; }

        public int? CashbackOfferId { get; set; }
        public CashbackOfferTbl? CashbackOffer { get; set; }

        public int? CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }

        // Add references to orders and maintenance records
        public int? OrderId { get; set; }
        public OrderTbl? Order { get; set; }

        public int? MaintenanceRecordId { get; set; }
        public MaintenanceRecordTbl? MaintenanceRecord { get; set; }
    }
}
