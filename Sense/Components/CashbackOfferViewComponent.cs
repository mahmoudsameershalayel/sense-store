using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SenseWeb.Components
{
    public class CashbackOfferViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public CashbackOfferViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var offer = await _mediator.Send(new GetAllCashbackOffersQuery());
            return View(offer.Data);
        }
    }
}
