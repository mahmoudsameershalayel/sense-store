using Sense.Domain.Enums;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.UseCases.Banner.Commands.CreateBannerCommand;
using Sense.Application.UseCases.Banner.Commands.DeleteBannerCommand;
using Sense.Application.UseCases.Banner.Commands.UpdateBannerCommand;
using Sense.Application.UseCases.Banner.Commands.UploadBannerImageCommand;
using Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery;
using Sense.Application.UseCases.Banner.Queries.GetBannerByIdQuery;
using Sense.Application.UseCases.Service.Commands.CreateServiceCommand;
using Sense.Application.UseCases.Service.Commands.DeleteServiceCommand;
using Sense.Application.UseCases.Service.Commands.UpdateServiceCommand;
using Sense.Application.UseCases.Service.Commands.UploadServiceImageCommand;
using Sense.Application.UseCases.Service.Queries.GetAllServicesQuery;
using Sense.Application.UseCases.Service.Queries.GetServiceByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class ServiceController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllServicesQuery { });
            var items = result.Data;
            ViewBag.ActiveMenu = "Service";
            ViewData["title"] = "الخدمات";
            return View(items);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ActiveMenu = "AddService";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new CreateServiceCommand { Dto = dto });

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
        public async Task<IActionResult> UploadImage(UploadServiceImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadServiceImageCommand { Dto = dto });
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
            var query = new GetServiceByIdQuery { ServiceId = id };
            var result = await _mediator.Send(query);
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int serviceId, ServiceForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UpdateServiceCommand { ServiceId = serviceId, Dto = dto });
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
            var result = await _mediator.Send(new DeleteServiceCommand { ServiceId = id });

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
