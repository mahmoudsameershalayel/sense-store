using Sense.Application.DTOs.CenterSettingDTOs;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SenseWeb.Components
{
    public class BrandingViewComponent : ViewComponent
    {
        private const string CacheKey = "CenterBrandingSetting";
        private const string DefaultCenterName = "مركز سدرا";
        private const string DefaultLogoUrl = "/assets/img/logo-default.png";

        private readonly IMediator _mediator;

        public BrandingViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(string variant = "text")
        {
            ViewBag.Variant = variant;

            if (HttpContext.Items[CacheKey] is not CenterSettingDto setting)
            {
                var result = await _mediator.Send(new GetCenterSettingQuery());
                setting = result.Data ?? new CenterSettingDto();

                if (string.IsNullOrWhiteSpace(setting.CenterName))
                    setting.CenterName = DefaultCenterName;

                if (string.IsNullOrWhiteSpace(setting.LogoUrl))
                    setting.LogoUrl = DefaultLogoUrl;

                HttpContext.Items[CacheKey] = setting;
            }

            return View(setting);
        }
    }
}
