using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Sense.Application.UseCases.MaintenanceRecord.Commands.CompleteMaintenanceRecordCommand
{
    public class CompleteMaintenanceRecordHandler : IRequestHandler<CompleteMaintenanceRecordCommand, ResponseResult<MaintenanceRecordDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IMapper _mapper;
        
        public CompleteMaintenanceRecordHandler(IRepositoryManager repositoryManager, IMapper mapper, UserManager<ApplicationUserTbl> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<MaintenanceRecordDto>> Handle(CompleteMaintenanceRecordCommand request, CancellationToken cancellationToken)
        {
            var maintenanceRecord = await _repositoryManager.MaintenanceRecord.GetMaintenanceRecordByIdAsync(request.MaintenanceRecordId);
            if (maintenanceRecord is null)
                return ResponseResult<MaintenanceRecordDto>.GetResult(ResultCodeStatus.NotFound, "Maintenance Record Not Found!!");
            
            var appointment = await _repositoryManager.Appointment.GetAppointmentByIdAsync(maintenanceRecord.AppointmentId);
            if (appointment is null)
                return ResponseResult<MaintenanceRecordDto>.GetResult(ResultCodeStatus.NotFound, "Appointment Not Found!!");

            var saudiTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time");
            var saudiTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, saudiTimeZone);

            maintenanceRecord.Status = MaintenanceStatus.Completed;
            appointment.Status = AppointmentStatus.Completed;
            maintenanceRecord.EndDate = saudiTime;
            
            _repositoryManager.MaintenanceRecord.UpdateMaintenanceRecord(maintenanceRecord);
            _repositoryManager.Appointment.UpdateAppointment(appointment);
            await _repositoryManager.SaveAsync();

            var allFreeMaintenanceOffer = await _repositoryManager.FreeMaintenanceEligibility.GetAllFreeMaintenanceEligibilitysAsync();

            var freeMaintenanceOffer = allFreeMaintenanceOffer
                .Where(x =>
                    x.CustomerId == maintenanceRecord.Appointment.Customer.Id &&
                    x.IsActivated &&
                    DateTime.UtcNow > x.ActivatedAt &&
                    DateTime.UtcNow < x.ExpiresAt &&
                    maintenanceRecord.Appointment.CreatedAt >= x.ActivatedAt
                )
                .FirstOrDefault();

            // Apply cashback logic for maintenance services
            if (freeMaintenanceOffer is null)
                await ApplyCashbackForMaintenance(maintenanceRecord);

            await ApplyCashbackForSparePart(maintenanceRecord);

                var dto = _mapper.Map<MaintenanceRecordDto>(maintenanceRecord);
            return ResponseResult<MaintenanceRecordDto>.GetResult(ResultCodeStatus.Created, dto, $"The Maintenance Record with Id : {maintenanceRecord.Id} completed successfully");
        }

        private async Task ApplyCashbackForMaintenance(MaintenanceRecordTbl maintenanceRecord)
        {
            try
            {
                // Get customer information
                var customer = await _repositoryManager.ApplicationUser.GetCustomerByIdAsync(maintenanceRecord.Appointment.CustomerId);
                if (customer == null) return;

                var user = await _userManager.FindByIdAsync(customer.ApplicationUserId);
                if (user == null) return;

                // Calculate total invoice amount for this maintenance record
                decimal totalInvoiceAmount = 0;
               if (maintenanceRecord.Invoices != null && maintenanceRecord.Invoices.Any(x => x.InvoiceType == InvoiceType.LaborCostInvoice))
                {
                    totalInvoiceAmount = maintenanceRecord.Invoices
                        .Where(i => i.InvoiceType == InvoiceType.LaborCostInvoice)
                        .Sum(i => i.InvoiceAmount);
                }

                // If no invoices or total is 0, skip cashback
                if (totalInvoiceAmount <= 0) return;

                // Get applicable cashback offers
                var cashBackOffers = await _repositoryManager.CashbackOffer.GetAllOffersAsync();
                
                // Filter active cashback offers that apply to labor cost and are within the valid date range
                var applicableCashBackOffers = cashBackOffers.Where(x => 
                    x.IsActive == true &&    
                    x.IsDeleted == false && 
                    x.IsApplyOnLaborCost == true &&  // Check if the offer applies to labor/maintenance services
                    x.StartDate <= DateTime.UtcNow && 
                    x.EndDate >= DateTime.UtcNow).ToList();

                if (applicableCashBackOffers.Any())
                {
                    // Find the best cashback offer (highest value)
                    CashbackOfferTbl bestCashBackOffer = null;
                    decimal bestCashBackValue = 0;

                    foreach (var offer in applicableCashBackOffers)
                    {
                        decimal potentialCashBackVal = 0;
                        switch (offer.CashbackType)
                        {
                            case CashbackType.Percentage:
                                potentialCashBackVal = (offer.CashbackVal / 100) * totalInvoiceAmount;
                                break;
                            case CashbackType.Fixed:
                                potentialCashBackVal = offer.CashbackVal;
                                break;
                        }

                        // Select the offer that gives the highest cashback value
                        if (potentialCashBackVal > bestCashBackValue)
                        {
                            bestCashBackValue = potentialCashBackVal;
                            bestCashBackOffer = offer;
                        }
                    }

                    if (bestCashBackOffer != null && bestCashBackValue > 0)
                    {
                        decimal cashBackVal = bestCashBackValue;

                        // Apply the cashback based on return type
                        switch (bestCashBackOffer.ReturnType)
                        {
                            case ReturnType.Points:
                                if (user.MyPoints == null)
                                    user.MyPoints = 0;
                                user.MyPoints += (int)cashBackVal;
                                await _userManager.UpdateAsync(user);

                                // Create points transaction record for cashback
                                var pointsTransaction = new PointsTransactionTbl
                                {
                                    CustomerId = customer.Id,
                                    PointsRedeemed = -(int)cashBackVal, // Negative because it's adding points (earning)
                                    AmountDeducted = 0, // No amount deducted since we're earning points
                                    PointsToSARRate = 1, // Default rate for earning points
                                    MaintenanceRecordId = maintenanceRecord.Id,
                                    CreatedAt = DateTime.UtcNow,
                                    Details = $"كاش باك نقاط من خدمة الصيانة - سجل رقم {maintenanceRecord.Id} - عرض: {bestCashBackOffer.Id}"
                                };
                                _repositoryManager.PointsTransaction.CreatePointsTransaction(pointsTransaction);
                                break;
                                
                            case ReturnType.CashOnWallet:
                                var wallet = await _repositoryManager.Wallet.GetWalletsByCustomerId(customer.Id);
                                if (wallet != null)
                                {
                                    wallet.Balance += (double)cashBackVal;
                                    _repositoryManager.Wallet.UpdateWallet(wallet);
                                    
                                    var transaction = new TransactionTbl
                                    {
                                        CustomerId = customer.Id,
                                        WalletId = wallet.Id,
                                        TransactionType = TransactionType.Cashback,
                                        Amount = cashBackVal,
                                        CreatedAt = DateTime.UtcNow,
                                        Details = $"استرداد نقدي من خدمة الصيانة - سجل رقم {maintenanceRecord.Id} - عرض: {bestCashBackOffer.Id}"
                                    };
                                    _repositoryManager.Transaction.CreateTransaction(transaction);
                                }
                                break;
                        }
                        // Create a record of cashback offer usage
                        var cashbackUsage = new CashbackOfferUsageTbl
                        {
                            CashbackOfferId = bestCashBackOffer.Id,
                            CustomerId = customer.Id,
                            MaintenanceRecordId = maintenanceRecord.Id,
                            CashbackVal = cashBackVal,
                            CreatedAt = DateTime.UtcNow
                        };
                        _repositoryManager.CashbackOfferUsage.CreateOfferUsage(cashbackUsage);

                        await _repositoryManager.SaveAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception but don't fail the main operation
                // You might want to add proper logging here
                // For now, we'll silently continue as cashback is a bonus feature
            }
        }

        private async Task ApplyCashbackForSparePart(MaintenanceRecordTbl maintenanceRecord)
        {
            try
            {
                // Get customer information
                var customer = await _repositoryManager.ApplicationUser.GetCustomerByIdAsync(maintenanceRecord.Appointment.CustomerId);
                if (customer == null) return;

                var user = await _userManager.FindByIdAsync(customer.ApplicationUserId);
                if (user == null) return;

                // Calculate total invoice amount for this maintenance record
                decimal totalInvoiceAmount = 0;
                if (maintenanceRecord.Invoices != null && maintenanceRecord.Invoices.Any(x => x.InvoiceType == InvoiceType.SparePartInvoice))
                {
                    totalInvoiceAmount = maintenanceRecord.Invoices
                        .Where(i => i.InvoiceType == InvoiceType.SparePartInvoice)
                        .Sum(i => i.InvoiceAmount);
                }

                // If no invoices or total is 0, skip cashback
                if (totalInvoiceAmount <= 0) return;

                // Get applicable cashback offers
                var cashBackOffers = await _repositoryManager.CashbackOffer.GetAllOffersAsync();

                // Filter active cashback offers that apply to spare parts and are within the valid date range
                var applicableCashBackOffers = cashBackOffers.Where(x =>
                    x.IsActive == true &&
                    x.IsDeleted == false && 
                    x.IsApplyOnSparePart == true &&  
                    x.StartDate <= DateTime.UtcNow &&
                    x.EndDate >= DateTime.UtcNow).ToList();

                if (applicableCashBackOffers.Any())
                {
                    // Find the best cashback offer (highest value)
                    CashbackOfferTbl bestCashBackOffer = null;
                    decimal bestCashBackValue = 0;

                    foreach (var offer in applicableCashBackOffers)
                    {
                        decimal potentialCashBackVal = 0;
                        switch (offer.CashbackType)
                        {
                            case CashbackType.Percentage:
                                potentialCashBackVal = (offer.CashbackVal / 100) * totalInvoiceAmount;
                                break;
                            case CashbackType.Fixed:
                                potentialCashBackVal = offer.CashbackVal;
                                break;
                        }

                        // Select the offer that gives the highest cashback value
                        if (potentialCashBackVal > bestCashBackValue)
                        {
                            bestCashBackValue = potentialCashBackVal;
                            bestCashBackOffer = offer;
                        }
                    }

                    if (bestCashBackOffer != null && bestCashBackValue > 0)
                    {
                        decimal cashBackVal = bestCashBackValue;

                        // Apply the cashback based on return type
                        switch (bestCashBackOffer.ReturnType)
                        {
                            case ReturnType.Points:
                                if (user.MyPoints == null)
                                    user.MyPoints = 0;
                                user.MyPoints += (int)cashBackVal;
                                await _userManager.UpdateAsync(user);

                                // Create points transaction record for cashback
                                var pointsTransaction = new PointsTransactionTbl
                                {
                                    CustomerId = customer.Id,
                                    PointsRedeemed = -(int)cashBackVal, // Negative because it's adding points (earning)
                                    AmountDeducted = 0, // No amount deducted since we're earning points
                                    PointsToSARRate = 1, // Default rate for earning points
                                    MaintenanceRecordId = maintenanceRecord.Id,
                                    CreatedAt = DateTime.UtcNow,
                                    Details = $"كاش باك نقاط من فاتورة قطع الغيار - سجل رقم {maintenanceRecord.Id} - عرض: {bestCashBackOffer.Id}"
                                };
                                _repositoryManager.PointsTransaction.CreatePointsTransaction(pointsTransaction);
                                break;

                            case ReturnType.CashOnWallet:
                                var wallet = await _repositoryManager.Wallet.GetWalletsByCustomerId(customer.Id);
                                if (wallet != null)
                                {
                                    wallet.Balance += (double)cashBackVal;
                                    _repositoryManager.Wallet.UpdateWallet(wallet);

                                    var transaction = new TransactionTbl
                                    {
                                        CustomerId = customer.Id,
                                        WalletId = wallet.Id,
                                        TransactionType = TransactionType.Cashback,
                                        Amount = cashBackVal,
                                        CreatedAt = DateTime.UtcNow,
                                        Details = $"استرداد نقدي من فاتورة قطع الغيار - سجل رقم {maintenanceRecord.Id} - عرض: {bestCashBackOffer.Id}"
                                    };
                                    _repositoryManager.Transaction.CreateTransaction(transaction);
                                }
                                break;
                        }

                        // Create a record of cashback offer usage
                        var cashbackUsage = new CashbackOfferUsageTbl
                        {
                            CashbackOfferId = bestCashBackOffer.Id,
                            CustomerId = customer.Id,
                            MaintenanceRecordId = maintenanceRecord.Id,
                            CashbackVal = cashBackVal,
                            CreatedAt = DateTime.UtcNow
                        };
                        _repositoryManager.CashbackOfferUsage.CreateOfferUsage(cashbackUsage);

                        await _repositoryManager.SaveAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception but don't fail the main operation
                // You might want to add proper logging here
                // For now, we'll silently continue as cashback is a bonus feature
            }
        }
    }
}
