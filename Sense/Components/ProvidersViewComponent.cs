using Sense.Application.UseCases.Provider.Queries.GetAllProvidersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class ProvidersViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ProvidersViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var providers = await _mediator.Send(new GetAllProvidersQuery());

            ViewBag.Providers = providers.Data;
            return View();
        }
    }
}
