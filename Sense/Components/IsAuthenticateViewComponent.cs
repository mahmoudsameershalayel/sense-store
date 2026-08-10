using Sense.Domain.DBEntities;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class IsAuthenticateViewComponent : ViewComponent
    {
        private static readonly object RequestCacheKey = new();
        private readonly UserManager<ApplicationUserTbl> _userManager;

        public IsAuthenticateViewComponent(UserManager<ApplicationUserTbl> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.User.Identity?.IsAuthenticated != true)
            {
                return View(new IsAuthenticateDto { FullName = "", ImageURL = null });
            }

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

            return user == null
                ? View(new IsAuthenticateDto { FullName = "", ImageURL = null })
                : View(new IsAuthenticateDto
                {
                    FullName = $"{user.FirstName} {user.LastName}",
                    ImageURL = user.ImageURL
                });
        }
    }
}
