
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.TransactionDTOs;
using Sense.Application.DTOs.WalletDTOs;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.FreeMaintenanceEligibilityDTOs;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.OrderDTOs;
using Sense.Application.DTOs.PointsDTOs;
using Sense.Application.Enums;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;

namespace Sense.Application.UseCases.ActivityLog.Queries.GenerateCustomerReportQuery
{
    public class GenerateCustomerReportHandler : IRequestHandler<GenerateCustomerReportQuery, ResponseResult<CustomerReportDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUserTbl> _userManager;

        public GenerateCustomerReportHandler(IRepositoryManager repositoryManager, IMapper mapper, UserManager<ApplicationUserTbl> userManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ResponseResult<CustomerReportDto>> Handle(GenerateCustomerReportQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CustomerId);

            if (customer == null)
                return ResponseResult<CustomerReportDto>.GetResult(ResultCodeStatus.NotFound, "Customer not found!");

            var user = await _userManager.FindByIdAsync(customer.ApplicationUserId);
            
            var allAppointments = await _repositoryManager.Appointment.GetAllAppointmentsAsync();
            var appointments = allAppointments
                .Where(a => a.CustomerId == customer.Id)
                .OrderByDescending(a => a.CreatedAt)
                .Take(10)
                .Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    CreatedAtDate = a.CreatedAt?.ToString("yyyy/MM/dd") ?? "غير محدد",
                    Status = a.Status.GetDisplayName(),
                    Details = a.Details
                })
                .ToList();

            var allInvoices = await _repositoryManager.Invoice.GetAllInvoicesAsync();
            var invoices = allInvoices
                .Where(i => i.MaintenanceRecord?.Appointment?.CustomerId == customer.Id)
                .OrderByDescending(i => i.CreatedAt)
                .Take(10)
                .Select(i => new InvoiceDto
                {
                    InvoiceNo = i.InvoiceNo,
                    CreatedAtDate = i.CreatedAt?.ToString("yyyy/MM/dd") ?? "غير محدد",
                    InvoiceAmount = i.InvoiceAmount,
                    InvoiceType = i.InvoiceType?.GetDisplayName() ?? "غير محدد"
                })
                .ToList();

            var allOrders = await _repositoryManager.Order.GetAllOrdersAsync();
            var orders = allOrders
                .Where(o => o.CustomerId == customer.Id)
                .OrderByDescending(o => o.OrderDate)
                .Take(10)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate?.ToString("yyyy/MM/dd") ?? "غير محدد",
                    OrderStatus = o.OrderStatus.GetDisplayName(),
                })
                .ToList();

            var recentLogs = customer.ActivityLogs?
                .OrderByDescending(l => l.CreatedAt)
                .Take(10)
                .Select(l => new CustomerActivityLogDto
                {
                    CreatedAt = l.CreatedAt?.ToString("yyyy/MM/dd") ?? "غير محدد",
                    ActivityType = l.ActivityType.GetDisplayName(),
                    Description = l.Description
                })
                .ToList() ?? new List<CustomerActivityLogDto>();

            // حساب إحصائيات للأنشطة (Chart Data)
            var activityStats = customer.ActivityLogs?
                .GroupBy(l => l.ActivityType)
                .Select(g => new { Type = g.Key.GetDisplayName(), Count = g.Count() })
                .ToDictionary(g => g.Type, g => g.Count) ?? new Dictionary<string, int>();

            // Get Points Information
            var currentPoints = user?.MyPoints ?? 0;
            var allPointsTransactions = await _repositoryManager.PointsTransaction.GetAllPointsTransactionsAsync();
            var pointsTransactions = allPointsTransactions
                .Where(pt => pt.CustomerId == customer.Id)
                .OrderByDescending(pt => pt.CreatedAt)
                .Select(pt => _mapper.Map<PointsTransactionDto>(pt))
                .ToList();

            // Get Wallet Information
            var wallet = await _repositoryManager.Wallet.GetWalletsByCustomerId(customer.Id);
            var walletDto = wallet != null ? _mapper.Map<WalletDto>(wallet) : null;
            var walletBalance = wallet?.Balance ?? 0;

            var allTransactions = await _repositoryManager.Transaction.GetAllTransactionsAsync();
            var walletTransactions = allTransactions
                .Where(t => t.CustomerId == customer.Id)
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => _mapper.Map<TransactionDto>(t))
                .ToList();

            // Get Maintenance Records Information
            var allMaintenanceRecords = await _repositoryManager.MaintenanceRecord.GetAllMaintenanceRecordsAsync(new Sense.Application.RequestFeatures.MaintenanceRecordParameters());
            var completedMaintenanceRecords = allMaintenanceRecords
                .Where(mr => mr.Appointment?.CustomerId == customer.Id && mr.Status == MaintenanceStatus.Completed)
                .Count();

            // Get Free Maintenance Offers Information
            var allFreeMaintenanceEligibilities = await _repositoryManager.FreeMaintenanceEligibility.GetAllFreeMaintenanceEligibilitysAsync();
            var freeMaintenanceOffers = allFreeMaintenanceEligibilities
                .Where(fme => fme.CustomerId == customer.Id)
                .Select(fme => _mapper.Map<FreeMaintenanceEligibilityDto>(fme))
                .ToList();

            // Check for active free maintenance offer
            var now = DateTime.UtcNow;
            var activeFreeMaintenanceOffer = allFreeMaintenanceEligibilities
                .Where(fme => fme.CustomerId == customer.Id && 
                             fme.IsActivated == true && 
                             fme.ActivatedAt.HasValue &&
                             fme.ExpiresAt.HasValue &&
                             now >= fme.ActivatedAt.Value && 
                             now <= fme.ExpiresAt.Value)
                .FirstOrDefault();

            var hasActiveFreeMaintenanceOffer = activeFreeMaintenanceOffer != null;
            var activeOfferTitle = activeFreeMaintenanceOffer?.FreeMaintenanceOffer?.Title;
            var activeOfferExpiryDate = activeFreeMaintenanceOffer?.ExpiresAt?.ToString("yyyy/MM/dd");
            var activeOfferRemainingDays = activeFreeMaintenanceOffer?.ExpiresAt.HasValue == true
                ? (int)Math.Max(0, (activeFreeMaintenanceOffer.ExpiresAt.Value - now).TotalDays)
                : (int?)null;

            var result = new CustomerReportDto
            {
                CustomerName = $"{customer.ApplicationUser?.FirstName ?? "غير محدد"} {customer.ApplicationUser?.LastName ?? "غير محدد"}",

                // Basic counts - safe null checking
                TotalAppointments = allAppointments.Count(a => a.CustomerId == customer.Id),
                TotalInvoices = allInvoices.Count(i => i.MaintenanceRecord?.Appointment?.CustomerId == customer.Id),
                TotalOrders = allOrders.Count(o => o.CustomerId == customer.Id),

                // Financial Information
                CurrentPoints = currentPoints,
                WalletBalance = (decimal)walletBalance,
                TotalPointsTransactions = pointsTransactions.Count,
                TotalWalletTransactions = walletTransactions.Count,

                // Free Maintenance Information
                CompletedMaintenanceRecords = completedMaintenanceRecords,
                HasActiveFreeMaintenanceOffer = hasActiveFreeMaintenanceOffer,
                ActiveOfferTitle = activeOfferTitle,
                ActiveOfferExpiryDate = activeOfferExpiryDate,
                ActiveOfferRemainingDays = activeOfferRemainingDays,

                // Lists
                Appointments = appointments,
                Invoices = invoices,
                Orders = orders,
                RecentLogs = recentLogs,
                ActivityLogStats = activityStats,

                // Detailed Financial Information
                PointsTransactions = pointsTransactions,
                WalletTransactions = walletTransactions,
                Wallet = walletDto,
                FreeMaintenanceOffers = freeMaintenanceOffers
            };

            return ResponseResult<CustomerReportDto>.GetResult(ResultCodeStatus.Success, result);
        }
    }
}