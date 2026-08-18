using Microsoft.AspNetCore.Mvc;
using Sense.Performance;

namespace Sense.Components
{
    public class SearchBarViewComponent : ViewComponent
    {
        private readonly StorefrontDataCache _storefrontData;

        public SearchBarViewComponent(StorefrontDataCache storefrontData)
        {
            _storefrontData = storefrontData;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string? formAction = null,
            string placeholder = "ابحث عن فئة محددة...",
            bool isMobile = false)
        {
            ViewBag.FormAction = formAction;
            ViewBag.Placeholder = placeholder;
            ViewBag.IsMobile = isMobile;
            ViewBag.Categories = await _storefrontData.GetCategoriesAsync();
            return View();
        }
    }
}
