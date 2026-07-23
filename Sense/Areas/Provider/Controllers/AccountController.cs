using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sense.Application.UseCases.ApplicationUser.Queries.GetUserByIdQuery;
using Sense.Areas.Provider.Models;
using Sense.Domain.DBEntities;
using System.Security.Claims;

namespace Sense.Areas.Provider.Controllers
{
    public class AccountController : ProviderBaseController
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly SignInManager<ApplicationUserTbl> _signInManager;
        private readonly IMediator _mediator;

        public AccountController(
            UserManager<ApplicationUserTbl> userManager,
            SignInManager<ApplicationUserTbl> signInManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            ViewBag.ActiveMenu = "Profile";
            ViewData["title"] = "ملفي الشخصي";

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = userId });

            return View(user.Data);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.ActiveMenu = "ChangePassword";
            ViewData["title"] = "تغيير كلمة المرور";

            return View(new ChangePasswordViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            ViewBag.ActiveMenu = "ChangePassword";
            ViewData["title"] = "تغيير كلمة المرور";

            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user is null)
                return Challenge();

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await _signInManager.RefreshSignInAsync(user);
            TempData["Message"] = "تم تغيير كلمة المرور بنجاح.";

            return RedirectToAction(nameof(ChangePassword));
        }
    }
}
