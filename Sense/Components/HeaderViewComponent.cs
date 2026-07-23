using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SenseWeb.Components
{
    public class HeaderViewComponent : ViewComponent
    {

        private readonly IMediator _mediator;

        public HeaderViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await _mediator.Send(new GetCenterSettingQuery());
            return View(setting.Data);
        }
    }
}
