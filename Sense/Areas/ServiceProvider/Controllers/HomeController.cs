using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.ServiceProvider.Controllers
{
    public class HomeController : ServiceProviderBaseController
    {
        public IActionResult Index()
            => RedirectToAction("Index", "ServiceListing", new { area = "ServiceProvider" });
    }
}
