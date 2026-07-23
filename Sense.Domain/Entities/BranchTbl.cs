using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class BranchTbl : BaseEntity
    {
        public string? BranchName { get; set; }
        public string? BranchAddress { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
		[Phone]
		public string? PhoneNumber { get; set; }
        public string? OpenAtTime { get; set; }
        public string? CloseAtTime { get; set; }

        public ICollection<AppointmentTbl> Appointments { get; set; } = new List<AppointmentTbl>();
        public ICollection<SupervisorTbl> Supervisors { get; set; } = new List<SupervisorTbl>();
    }
}
