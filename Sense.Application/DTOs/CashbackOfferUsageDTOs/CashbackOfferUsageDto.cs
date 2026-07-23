using Sense.Domain.DBEntities;
using Sense.Application.DTOs.OfferCashbackDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CashbackOfferUsageDTOs
{
    public class CashbackOfferUsageDto
    {
        public int Id { get; set; }
        public decimal? CashbackVal { get; set; }
        public int? CashbackOfferId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public int? MaintenanceRecordId { get; set; }
        public string DateUsed { get; set; }
        public string TimeUsed { get; set; }
        
        // Include cashback offer details
        public CashbackOfferDto? CashbackOffer { get; set; }
    }
}
