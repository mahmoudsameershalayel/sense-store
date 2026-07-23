using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class PhoneVerificationTbl
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OTP { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
