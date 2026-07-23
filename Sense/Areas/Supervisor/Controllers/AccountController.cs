using Sense.Domain.DBEntities;
using Sense.Application.UseCases.ApplicationUser.Queries.GetUserByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sense.Areas.Supervisor.Controllers
{
    public class AccountController : SupervisorBaseController
    {
        private readonly SignInManager<ApplicationUserTbl> _signInManager;
        private readonly IMediator _mediator;
        public AccountController(SignInManager<ApplicationUserTbl> signInManager, IMediator mediator)
        {
            _signInManager = signInManager;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = userId });
            return View(user.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
