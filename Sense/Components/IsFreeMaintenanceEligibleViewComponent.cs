using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetOfferEligibilityByCustomerIdQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordByCustomerIdQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class IsFreeMaintenanceEligibleViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public IsFreeMaintenanceEligibleViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int customerId, FreeMaintenanceOfferDto offer)
        {
            var maintenanceRecords = await _mediator.Send(new GetAllMaintenanceRecordsQuery { maintenanceRecordParameters = new MaintenanceRecordParameters() });
            ViewBag.CompletedAppointments = maintenanceRecords.Data.Where(x => x.CustomerId == customerId && x.Status == "Completed").ToList().Count();
            
            var eligible = await _mediator.Send(new GetOfferEligibilityByCustomerIdQuery { CustomerId = customerId, FreeMaintenanceOfferId = offer.Id });
            if (eligible.Data is null)
            {
                ViewBag.IsActivated = false;
                ViewBag.EligibilityData = null;
            }
            else
            {
                ViewBag.IsActivated = eligible.Data.IsActivated;
                ViewBag.EligibilityData = eligible.Data;
            }
            
            return View(offer);
        }
    }
}
