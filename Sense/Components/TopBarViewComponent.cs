using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Application.UseCases.Coupon.Queries.GetAllCouponsQuery;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetAllFreeMaintenanceOfferQuery;
using Sense.Application.UseCases.Statement.Queries.GetActiveStatementsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class TopBarViewComponent : ViewComponent
    {

        private readonly IMediator _mediator;

        public TopBarViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await _mediator.Send(new GetCenterSettingQuery());
            var coupons = await _mediator.Send(new GetAllCouponsQuery());
            var cashBackOffers = await _mediator.Send(new GetAllCashbackOffersQuery());
            var freeMaintenanceOffer = await _mediator.Send(new GetAllFreeMaintenanceOfferQuery());
            var statements = await _mediator.Send(new GetActiveStatementsQuery());

            ViewBag.Setting = setting.Data;
            ViewBag.Coupons = coupons.Data;
            ViewBag.CashBackOffers = cashBackOffers.Data;
            ViewBag.FreeMaintenanceOffer = freeMaintenanceOffer.Data;
            ViewBag.Statements = statements.Data;
            return View();
        }
    }
}
