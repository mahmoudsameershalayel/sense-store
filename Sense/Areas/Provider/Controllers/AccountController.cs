using Ganss.Xss;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sense.Application.Abstractions;
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
        private readonly IRepositoryManager _repositoryManager;
        private readonly IHtmlSanitizer _htmlSanitizer;

        public AccountController(
            UserManager<ApplicationUserTbl> userManager,
            SignInManager<ApplicationUserTbl> signInManager,
            IMediator mediator,
            IRepositoryManager repositoryManager,
            IHtmlSanitizer htmlSanitizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mediator = mediator;
            _repositoryManager = repositoryManager;
            _htmlSanitizer = htmlSanitizer;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            ViewBag.ActiveMenu = "Profile";
            ViewData["title"] = "ملفي الشخصي";

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return Challenge();

            return View(await BuildProfileViewModelAsync(userId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProviderProfileViewModel model)
        {
            ViewBag.ActiveMenu = "Profile";
            ViewData["title"] = "ملفي الشخصي";

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userId))
                return Challenge();

            if (!ModelState.IsValid)
            {
                var profile = await BuildProfileViewModelAsync(userId);
                profile.BusinessDescription = model.BusinessDescription;
                return View(profile);
            }

            var businessDescription = _htmlSanitizer.Sanitize(model.BusinessDescription).Trim();
            if (string.IsNullOrWhiteSpace(businessDescription))
            {
                ModelState.AddModelError(nameof(model.BusinessDescription), "وصف النشاط التجاري مطلوب.");
                var profile = await BuildProfileViewModelAsync(userId);
                profile.BusinessDescription = model.BusinessDescription;
                return View(profile);
            }

            var provider = await _repositoryManager.Provider.GetProviderByApplicationUserId(userId);
            if (provider is null)
                return NotFound();

            provider.Description = businessDescription;
            _repositoryManager.Provider.UpdateProvider(provider);
            await _repositoryManager.SaveAsync();

            TempData["Message"] = "تم تحديث وصف النشاط التجاري بنجاح.";
            return RedirectToAction(nameof(Profile));
        }

        private async Task<ProviderProfileViewModel> BuildProfileViewModelAsync(string userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = userId });
            var provider = await _repositoryManager.Provider.GetProviderByApplicationUserId(userId);

            return new ProviderProfileViewModel
            {
                User = user.Data,
                BusinessDescription = provider?.Description ?? string.Empty
            };
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
