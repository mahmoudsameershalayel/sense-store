using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.UseCases.ApplicationUser.Commands.CreateUserCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateSupervisorCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserAccountStatusCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UploadUserImageCommand;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllUsersQuery;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.TechSupport.Queries.GetAllTechSupportsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class TechSupportController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public TechSupportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(UserParameters? userParameters)
        {
            var result = await _mediator.Send(new GetAllUsersQuery { UserType = UserType.TechSupport, UserParameters = userParameters });
            var items = result.Data;
            ViewBag.ActiveMenu = "TechSupports";
            ViewData["title"] = "الدعم الفني";
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(UserForRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);                           

            var result = await _mediator.Send(new CreateUserCommand { UserType = UserType.TechSupport, Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
          
        [HttpGet]
        public IActionResult UploadImage(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadUserImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadUserImageCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            var result = await _mediator.Send(new UpdateUserAccountStatusCommand { UserId = id });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return Json(new { success = false, message = result.Result.Message });
            }

            TempData["Message"] = result.Result.Message;
            return Json(new { success = true, id = id, message = result.Result.Message });
        }

    }
}
