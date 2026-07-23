using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CenterSettingDTOs
{
    public class CenterSettingForUpdateDto
    {
        public int Id { get; set; }
        public string? CenterName { get; set; } = "???? ????";
        public string? LogoUrl { get; set; } = "/assets/img/????? - ???? - Canva - Google Chrome? 28_04_2025 23_36_59.png";
        public string? FaviconUrl { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
        
        // Points Configuration
        public decimal PointsToSARRate { get; set; } = 1.0m;
        public int MinRedeemPoints { get; set; } = 100;
        public int MaxRedeemPoints { get; set; } = 10000;

        public decimal DeliveryFee { get; set; }
    }
}
