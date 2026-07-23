using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class MaintenanceRecordTbl : BaseEntity
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public MaintenanceStatus Status { get; set; }

        public int AppointmentId { get; set; }
        public AppointmentTbl? Appointment { get; set; }

        public int SupervisorId { get; set; }
        public SupervisorTbl? Supervisor { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public ICollection<InvoiceTbl> Invoices { get; set; } = new List<InvoiceTbl>();
        public ICollection<CashbackOfferUsageTbl> CashbackUsages { get; set; } = new List<CashbackOfferUsageTbl>();
    }
}
