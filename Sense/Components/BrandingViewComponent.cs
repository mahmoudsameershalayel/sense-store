using Sense.Application.DTOs.CenterSettingDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sense.Performance;

namespace SenseWeb.Components
{
    public class BrandingViewComponent : ViewComponent
    {
        private readonly StorefrontDataCache _storefrontData;

        public BrandingViewComponent(StorefrontDataCache storefrontData)
        {
            _storefrontData = storefrontData;
        }

        public async Task<IViewComponentResult> InvokeAsync(string variant = "text")
        {
            ViewBag.Variant = variant;

            var setting = await _storefrontData.GetCenterSettingAsync()
                ?? new CenterSettingDto();

            return View(setting);
        }
    }
}
