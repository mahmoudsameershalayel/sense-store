using Sense.Domain.DBEntities;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class IsAuthenticateViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;

        public IsAuthenticateViewComponent(UserManager<ApplicationUserTbl> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User); // Get the logged-in user

            if (user != null && HttpContext.User.Identity.IsAuthenticated)
            {
                var profileImagePath = user.ImageURL; // Use default if null
                return View(new IsAuthenticateDto { FullName = $"{user.FirstName} {user.LastName}" , ImageURL = profileImagePath}); // Return the username and image path to the view
            }

            return View(new IsAuthenticateDto { FullName = "", ImageURL = null }); // Return default avatar if not authenticated
        }
    }
}
