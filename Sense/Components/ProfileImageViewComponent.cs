using Sense.Domain.DBEntities;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class ProfileImageViewComponent : ViewComponent
    {
        private static readonly object RequestCacheKey = new();
        private readonly UserManager<ApplicationUserTbl> _userManager;

        public ProfileImageViewComponent(UserManager<ApplicationUserTbl> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ApplicationUserTbl? user;
            if (HttpContext.Items.TryGetValue(RequestCacheKey, out var cachedUser))
            {
                user = cachedUser as ApplicationUserTbl;
            }
            else
            {
                user = await _userManager.GetUserAsync(HttpContext.User);
                HttpContext.Items[RequestCacheKey] = user;
            }

            if (user != null && HttpContext.User.Identity?.IsAuthenticated == true && user.ImageURL != null)
            {
                var profileImagePath = user.ImageURL;
                ViewBag.ProfileImage = profileImagePath;
                return View(); // Return the username and image path to the view
            }
            ViewBag.ProfileImage = null;
            return View(); // Return default avatar if not authenticated
        }
    }
}
