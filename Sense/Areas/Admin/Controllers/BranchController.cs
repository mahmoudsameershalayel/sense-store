using Sense.Domain.Enums;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.BranchDTOs;
using Sense.Application.UseCases.Banner.Commands.CreateBannerCommand;
using Sense.Application.UseCases.Banner.Commands.DeleteBannerCommand;
using Sense.Application.UseCases.Banner.Commands.UpdateBannerCommand;
using Sense.Application.UseCases.Banner.Commands.UploadBannerImageCommand;
using Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery;
using Sense.Application.UseCases.Banner.Queries.GetBannerByIdQuery;
using Sense.Application.UseCases.Branch.Commands.CreateBranchCommand;
using Sense.Application.UseCases.Branch.Commands.DeleteBranchCommand;
using Sense.Application.UseCases.Branch.Commands.UpdateBranchCommand;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.Branch.Queries.GetBranchByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
	public class BranchController : AdminBaseController
	{
		private readonly IMediator _mediator;
		public BranchController(IMediator mediator)
		{
			_mediator = mediator;
		}
		public async Task<IActionResult> Index()
		{
			var result = await _mediator.Send(new GetAllBranchesQuery { });
			var items = result.Data;
			ViewBag.ActiveMenu = "Branch";
			ViewData["title"] = "الفروع";
			return View(items);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			ViewBag.ActiveMenu = "AddBranch";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(BranchForCreateUpdateDto dto)
		{
			if (!ModelState.IsValid)
				return View(dto);

			var result = await _mediator.Send(new CreateBranchCommand { Dto = dto });

			if (result.Result.Code != ResultCodeStatus.Created)
			{
				TempData["ErrorMessage"] = result.Result.Message;
				return RedirectToAction(nameof(Index));
			}
			TempData["Message"] = result.Result.Message;
			return RedirectToAction(nameof(Index));
		}
	
	
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var query = new GetBranchByIdQuery { BranchId = id };
			var result = await _mediator.Send(query);
			return View(result.Data);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int branchId, BranchForCreateUpdateDto dto)
		{
			if (!ModelState.IsValid)
				return View();

			var result = await _mediator.Send(new UpdateBranchCommand { BranchId = branchId, Dto = dto });
			if (result.Result.Code != ResultCodeStatus.Success)
			{
				TempData["ErrorMessage"] = result.Result.Message;
				return RedirectToAction(nameof(Index));
			}
			TempData["Message"] = result.Result.Message;
			return RedirectToAction("Index");
		}
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _mediator.Send(new DeleteBranchCommand { BranchId = id });

			if (result.Result.Code != ResultCodeStatus.Success)
			{
				TempData["ErrorMessage"] = result.Result.Message;
				return RedirectToAction(nameof(Index));
			}
			TempData["Message"] = result.Result.Message;
			return Json(new { id = id, message = "Deleted Successfully" });

		}

	}
}
