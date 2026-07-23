using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.RequestFeatures
{
    public class AppointmentParameters : RequestParameters
    {
        public AppointmentStatus? Status { get; set; }
        public int? BranchId { get; set; }
        public int? BrandId { get; set; }
        public int? ServiceId { get; set; }
    }
}
