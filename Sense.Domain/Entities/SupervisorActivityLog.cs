using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class SupervisorActivityLog : BaseEntity
    {

        public int SupervisorId { get; set; }
        public SupervisorTbl Supervisor { get; set; }

        public string? Description { get; set; }
        public ActivityType? ActivityType { get; set; }
    }
}
