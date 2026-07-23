using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.OTPDTOs
{
    public class GenerateOTPDto
    {
        public required string PhoneNumber { get; set; }
    }
}
