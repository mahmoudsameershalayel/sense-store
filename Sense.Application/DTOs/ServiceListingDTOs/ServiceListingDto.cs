using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ServiceListingDTOs
{
    public class ServiceListingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageURL { get; set; }

        public ServiceListingStatus Status { get; set; }

        public int? ServiceProviderId { get; set; }
        public string? ServiceProviderName { get; set; }
    }
}
