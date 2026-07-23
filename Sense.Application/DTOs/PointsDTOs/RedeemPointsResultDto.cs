using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.PointsDTOs
{
    public class RedeemPointsResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public decimal AmountDeducted { get; set; }
        public int PointsRedeemed { get; set; }
        public int RemainingPoints { get; set; }
        public decimal PointsToSARRate { get; set; }
    }
}