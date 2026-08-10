using Sense.Application.UseCases.Provider.Queries.GetAllProvidersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sense.Performance;

namespace Sense.Components
{
    public class ProvidersViewComponent : ViewComponent
    {
        private readonly StorefrontDataCache _storefrontData;

        public ProvidersViewComponent(StorefrontDataCache storefrontData)
        {
            _storefrontData = storefrontData;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var providers = await _storefrontData.GetProvidersAsync();

            ViewBag.Providers = providers;
            return View();
        }
    }
}
