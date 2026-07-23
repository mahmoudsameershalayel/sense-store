using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class ConnectionTbl
    {
        [Key]
        public string? ConnectionId { get; set; }

        public string? UserId { get; set; }
        public ApplicationUserTbl? User { get; set; }
    }
}
