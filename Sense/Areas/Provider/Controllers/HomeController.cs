using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Provider.Controllers
{
    public class HomeController : ProviderBaseController
    {
        public IActionResult Index()
            => RedirectToAction("Index", "Product", new { area = "Provider" });
    }
}
