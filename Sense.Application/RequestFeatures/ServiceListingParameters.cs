using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.RequestFeatures
{
    public class ServiceListingParameters : RequestParameters
    {
        public string? ServiceListingName { get; set; } // Filter by service listing name
        public ServiceListingStatus? Status { get; set; } // Filter by approval/visibility status
        public int? ServiceProviderId { get; set; } // Filter by service provider
    }
}
