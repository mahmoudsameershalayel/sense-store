using Sense.Application.UseCases.ApplicationUser.Queries.GetUserByIdQuery;
using Sense.Application.UseCases.ChatMessage.Queries.GetRelevantUsersByTechSupportIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SenseWeb.Areas.TechSupport.Controllers
{
    [Area("TechSupport")]
    [Authorize(Roles = "TechSupport")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _mediator.Send(new GetUserByIdQuery { UserId = userId });
            var users = await _mediator.Send(new GetRelevantUsersByTechSupportIdQuery { CurrentUserId = userId });
            ViewBag.Users = users.Data;  
            ViewBag.CurrentUser = currentUser.Data;  
            return View();
        }
    }
}
