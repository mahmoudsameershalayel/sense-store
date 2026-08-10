using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class ServiceProviderTbl : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUserTbl? ApplicationUser { get; set; }

        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public string? LogoURL { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<ServiceListingTbl> ServiceListings { get; set; } = new List<ServiceListingTbl>();
    }
}
