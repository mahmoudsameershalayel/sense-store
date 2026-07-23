using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class CustomerActivityLog : BaseEntity
    {
        public int CustomerId { get; set; }
        public CustomerTbl Customer { get; set; }

        public string? Description { get; set; }
        public CustomerActivityType? ActivityType { get; set; }
    }
}
