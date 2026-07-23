using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class ChatSessionTbl
    {
        public int Id { get; set; }
        public string UserId { get; set; } // The user
        public string TechSupportId { get; set; } // The first tech support who responded
        public bool IsClosed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
