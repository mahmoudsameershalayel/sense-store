using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.CashbackOfferUsageDTOs;
using Sense.Application.DTOs.FreeMaintenanceEligibilityDTOs;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.PointsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.MaintenanceRecordDTOs
{
    public class MaintenanceRecordDetailDto
    {
        public int Id { get; set; }

        public string? StartDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndDate { get; set; }
        public string? EndTime { get; set; }

        public bool IsFreeMaintenanceOfferActive { get; set; }
        public bool IsCashbakOfferActive { get; set; }

        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }

        public virtual AppointmentDto Appointment { get; set; } = new AppointmentDto();
        public ICollection<InvoiceDto> Invoices { get; set; } = new List<InvoiceDto>();
        public ICollection<CashbackOfferUsageDto> CashbackUsages { get; set; } = new List<CashbackOfferUsageDto>();

        // Points discount information
        public PointsTransactionDto? PointsTransaction { get; set; }

        // Free maintenance offer information
        public FreeMaintenanceEligibilityDto? FreeMaintenanceEligibility { get; set; }

        public decimal TotalCost
        {
            get
            {
                return Invoices.Sum(invoice => invoice.InvoiceAmount);
            }
        }

        public decimal TotalCashbackReceived
        {
            get
            {
                return CashbackUsages.Sum(usage => usage.CashbackVal ?? 0);
            }
        }

        public decimal PointsDiscount
        {
            get
            {
                return PointsTransaction?.AmountDeducted ?? 0;
            }
        }

        public decimal FinalTotalAfterDiscounts
        {
            get
            {
                var baseTotal = Invoices
                    .Where(i => !(IsFreeMaintenanceOfferActive && i.InvoiceType == "LaborCostInvoice"))
                    .Sum(i => i.InvoiceAmount);
                
                return baseTotal - PointsDiscount;
            }
        }
    }

}
