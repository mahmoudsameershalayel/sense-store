using Sense.Domain.DBEntities;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class ProfileImageViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;

        public ProfileImageViewComponent(UserManager<ApplicationUserTbl> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User); // Get the logged-in user

            if (user != null && HttpContext.User.Identity.IsAuthenticated && user.ImageURL != null)
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
