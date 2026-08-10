using Sense.Application.DTOs.CenterSettingDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sense.Performance;

namespace SenseWeb.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly StorefrontDataCache _storefrontData;

        public FooterViewComponent(StorefrontDataCache storefrontData)
        {
            _storefrontData = storefrontData;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await _storefrontData.GetCenterSettingAsync();

            return View(setting ?? new CenterSettingDto
            {
                CenterName = "مركز سدرا",
                LogoUrl = "/assets/img/logo-default.png",
                Address = string.Empty,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                TwitterUrl = "#",
                FacebookUrl = "#",
                InstagramUrl = "#",
                LinkedInUrl = "#"
            });
        }
    }
}
