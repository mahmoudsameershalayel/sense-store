using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.PointsDTOs
{
    public class PointsInfoDto
    {
        public int CurrentPoints { get; set; }
        public decimal PointsToSARRate { get; set; }
        public int MinRedeemPoints { get; set; }
        public int MaxRedeemPoints { get; set; }
        public bool CanRedeem { get; set; }
        public bool AlreadyRedeemed { get; set; }
        public string? CustomerName { get; set; }
    }
}