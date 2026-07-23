using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class AppointmentTbl : BaseEntity
    {   
        public string? VehicleType { get; set; }         
        public string? ModelYear { get; set; }
        public string? Details { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public string? RejectReason { get; set; }
        public ServiceType? ServiceType { get; set; }

        public int? BrandId { get; set; }
        public BrandTbl? Brand { get; set; }

        public int? ModelId { get; set; }
        public ModelTbl? Model { get; set; }

        public int CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }

        public int? ServiceId { get; set; }
        public ServiceTbl? Service { get; set; }

        public int? BranchId { get; set; }
        public BranchTbl? Branch { get; set; }

        public int? SupervisorId { get; set; }
        public SupervisorTbl? Supervisor { get; set; }


    }
}
