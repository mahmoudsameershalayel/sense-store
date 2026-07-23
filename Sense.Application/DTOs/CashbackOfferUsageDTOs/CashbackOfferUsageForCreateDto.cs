using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CashbackOfferUsageDTOs
{
    public class CashbackOfferUsageForCreateDto
    {
        public int CashbackOfferId { get; set; }
        public decimal ServiceAmount { get; set; }

    }
}
