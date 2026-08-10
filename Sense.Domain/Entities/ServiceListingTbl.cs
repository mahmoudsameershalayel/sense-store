using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class ServiceListingTbl : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageURL { get; set; }
        public ServiceListingStatus Status { get; set; } = ServiceListingStatus.Draft;

        public int? ServiceProviderId { get; set; }
        public ServiceProviderTbl? ServiceProvider { get; set; }
    }
}
