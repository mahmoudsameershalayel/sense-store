using Sense.Domain.DBEntities;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.FreeMaintenanceEligibilityDTOs
{
    public class FreeMaintenanceEligibilityDto
    {
        public int Id { get; set; }
        public bool? IsEligible { get; set; }
        public bool? IsActivated { get; set; }
        public string? ActivatedAtDate { get; set; }
        public string? ActivatedAtTime { get; set; }
        public string? ExpiresAtDate { get; set; }
        public string? ExpiresAtTime { get; set; }

        // Add DateTime properties for compatibility
        public DateTime? ActivatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public CustomerDto? Customer { get; set; }
        public FreeMaintenanceOfferDto? FreeMaintenanceOffer { get; set; }
    }
}
