using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class SupervisorTbl : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUserTbl ApplicationUser { get; set; }

        public int? BranchId { get; set; }
        public virtual BranchTbl? Branch { get; set; }

        public ICollection<MaintenanceRecordTbl> MaintenanceRecords { get; set; } = new List<MaintenanceRecordTbl>();
        public ICollection<AppointmentTbl> Appointments { get; set; } = new List<AppointmentTbl>();
        public ICollection<SupervisorActivityLog> ActivityLogs { get; set; } = new List<SupervisorActivityLog>();

    }
}
