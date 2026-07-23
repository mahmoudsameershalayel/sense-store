using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.FreeMaintenanceEligibilityDTOs;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.OrderDTOs;
using Sense.Application.DTOs.PointsDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.DTOs.TransactionDTOs;
using Sense.Application.DTOs.WalletDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.CustomerDTOs
{
    public class CustomerReportDto
    {
        public string CustomerName { get; set; }

        public int TotalAppointments { get; set; }
        public int TotalInvoices { get; set; }
        public int TotalOrders { get; set; }

        // Financial Information
        public int CurrentPoints { get; set; }
        public decimal WalletBalance { get; set; }
        public int TotalPointsTransactions { get; set; }
        public int TotalWalletTransactions { get; set; }

        // Free Maintenance Information
        public int CompletedMaintenanceRecords { get; set; }
        public bool HasActiveFreeMaintenanceOffer { get; set; }
        public string? ActiveOfferTitle { get; set; }
        public string? ActiveOfferExpiryDate { get; set; }
        public int? ActiveOfferRemainingDays { get; set; }

        // Optional: Add more stats
        public Dictionary<string, int> ActivityLogStats { get; set; }

        public List<AppointmentDto> Appointments { get; set; }
        public List<InvoiceDto> Invoices { get; set; }
        public List<OrderDto> Orders { get; set; }
        public List<CustomerActivityLogDto> RecentLogs { get; set; }

        // New detailed information
        public List<PointsTransactionDto> PointsTransactions { get; set; } = new List<PointsTransactionDto>();
        public List<TransactionDto> WalletTransactions { get; set; } = new List<TransactionDto>();
        public WalletDto? Wallet { get; set; }
        public List<FreeMaintenanceEligibilityDto> FreeMaintenanceOffers { get; set; } = new List<FreeMaintenanceEligibilityDto>();
    }
}
