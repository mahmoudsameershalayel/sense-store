using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetAllFreeMaintenanceOfferQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Controllers
{
    public class CashbackOfferController : Controller
    {
        private readonly IMediator _mediator;
        public CashbackOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllCashbackOffersQuery { });
            var items = result.Data;
            return View(items);
        }
    }
}
