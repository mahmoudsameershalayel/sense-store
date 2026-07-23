using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class SearchBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string formAction = null, string placeholder = "ابحث عن زيوت السيارات")
        {
            ViewBag.FormAction = formAction;
            ViewBag.Placeholder = placeholder;
            return View();
        }
    }
}
