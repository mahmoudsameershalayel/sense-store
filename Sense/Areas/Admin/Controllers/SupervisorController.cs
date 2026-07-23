using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.UseCases.ApplicationUser.Commands.CreateUserCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateSupervisorCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserAccountStatusCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UploadUserImageCommand;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllSupervisorsQuery;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllUsersQuery;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.Product.Commands.DeleteProductCommand;
using Sense.Application.UseCases.Supervisor.Commands.DisableSupervisorCommand;
using Sense.Application.UseCases.Supervisor.Queries.GetSupervisorActivityReportQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sense.Areas.Admin.Controllers
{
    public class SupervisorController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public SupervisorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(UserParameters? userParameters)
        {
            var result = await _mediator.Send(new GetAllUsersQuery { UserType = UserType.Supervisor,UserParameters = userParameters });
            var items = result.Data;

            ViewBag.CurrentPage = userParameters.PageNumber;
            ViewBag.PageSize = userParameters.PageSize;
            ViewBag.SearchTerm = userParameters.Name;
            ViewBag.TotalPages = result.Data.MetaData.TotalPages;

            ViewBag.ActiveMenu = "Supervisors";
            ViewData["title"] = "المشرفون";
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _mediator.Send(new GetAllBranchesQuery { });
            ViewBag.Branches = result.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int branchId , UserForRegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                var branches = await _mediator.Send(new GetAllBranchesQuery { });
                ViewBag.Branches = branches.Data;
                return View(dto);
            }

            var result = await _mediator.Send(new CreateUserCommand { UserType = UserType.Supervisor, BranchId = branchId,Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupervisor([FromBody] SupervisorForUpdateDto dto)
        {

            if (ModelState.IsValid)
            {

                var user = await _mediator.Send(new UpdateSupervisorCommand { Dto = dto });

                if (user.Data != null)
                {
                    return Ok(user.Data);
                }
                else
                {
                    return BadRequest("Failed to update profile.");
                }
            }

            return BadRequest(ModelState);
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
        [HttpGet]
        public async Task<IActionResult> ActivityReport(string id)
        {
            var result = await _mediator.Send(new GetSupervisorActivityReportQuery {SupervisorId = id });
            return View(result.Data);
        }

    }
}
