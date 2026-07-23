using Sense.Application.DTOs.CenterSettingDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Application.UseCases.Service.Queries.GetAllServicesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SenseWeb.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public FooterViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await _mediator.Send(new GetCenterSettingQuery());
            var services = await _mediator.Send(new GetAllServicesQuery());

            ViewBag.Services = services.Data?.ToList() ?? new List<ServiceDto>();

            return View(setting.Data ?? new CenterSettingDto
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