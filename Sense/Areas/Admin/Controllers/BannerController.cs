using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Banner.Commands.CreateBannerCommand;
using Sense.Application.UseCases.Banner.Commands.DeleteBannerCommand;
using Sense.Application.UseCases.Banner.Commands.UpdateBannerCommand;
using Sense.Application.UseCases.Banner.Commands.UploadBannerImageCommand;
using Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery;
using Sense.Application.UseCases.Banner.Queries.GetBannerByIdQuery;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class BannerController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public BannerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllBannersQuery { });
            var items = result.Data;
            ViewBag.ActiveMenu = "Banner";
            ViewData["title"] = "البانرات";
            return View(items);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
			ViewBag.ActiveMenu = "AddBanner";
			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BannerForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new CreateBannerCommand { Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UploadImage(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadBannerImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadBannerImageCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetBannerByIdQuery { BannerId = id };
            var result = await _mediator.Send(query);
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int bannerId, BannerForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UpdateBannerCommand { BannerId = bannerId, Dto = dto });
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
            var result = await _mediator.Send(new DeleteBannerCommand { BannerId = id });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return Json(new
                {
                    success = false,
                    message = result.Result.Message
                });
            }
            TempData["Message"] = result.Result.Message;
            return Json(new { success = false , message = result.Result.Message });

        }

    }
}
