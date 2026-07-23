using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class TechSupportTbl : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUserTbl ApplicationUser { get; set; }

    }
}
