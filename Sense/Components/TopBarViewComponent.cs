using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Application.UseCases.Coupon.Queries.GetAllCouponsQuery;
using Sense.Application.UseCases.Statement.Queries.GetActiveStatementsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sense.Performance;

namespace Sense.Components
{
    public class TopBarViewComponent : ViewComponent
    {

        private readonly StorefrontDataCache _storefrontData;

        public TopBarViewComponent(StorefrontDataCache storefrontData)
        {
            _storefrontData = storefrontData;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await _storefrontData.GetCenterSettingAsync();
            var coupons = await _storefrontData.GetCouponsAsync();
            var cashBackOffers = await _storefrontData.GetCashbackOffersAsync();
            var statements = await _storefrontData.GetStatementsAsync();

            ViewBag.Setting = setting;
            ViewBag.Coupons = coupons;
            ViewBag.CashBackOffers = cashBackOffers;
            ViewBag.Statements = statements;
            return View();
        }
    }
}
