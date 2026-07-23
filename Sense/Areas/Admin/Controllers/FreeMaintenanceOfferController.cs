using Sense.Domain.Enums;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.UseCases.Cateogry.Commands.UploadCategoryImageCommand;
using Sense.Application.UseCases.FreeMaintenanceOffer.Commands.CreateFreeMaintenanceOfferCommand;
using Sense.Application.UseCases.FreeMaintenanceOffer.Commands.DeleteFreeMaintenanceOfferCommand;
using Sense.Application.UseCases.FreeMaintenanceOffer.Commands.UpdateFreeMaintenanceOfferStatusCommand;
using Sense.Application.UseCases.FreeMaintenanceOffer.Commands.UploadFreeMaintenanceOfferImageCommand;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetAllFreeMaintenanceOfferQuery;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.LoadFreeMaintenanceOfferQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Areas.Admin.Controllers
{
    public class FreeMaintenanceOfferController : AdminBaseController
    {
        private readonly IMediator _mediator;

        public FreeMaintenanceOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllFreeMaintenanceOfferQuery { };
            var result = await _mediator.Send(query);
            ViewBag.ActiveMenu = "FreeMaintenanceOffer";
            ViewData["title"] = "عروض الصيانة المجانية";
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> LoadFreeMaintenanceOffers()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");

            var queryResult = await _mediator.Send(new LoadFreeMaintenanceOfferQuery());
            var query = queryResult.Data;

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderBy(x => x.Id)
                .Skip(start)
                .Take(length)
                .Select(c => new
                {
                    id = c.Id,
                    imageURL = c.ImageURL,
                    title = c.Title,
                    description = c.Description,
                    requiredAppointments = c.RequiredAppointments,
                    freePeriodInDays = c.FreePeriodInDays,
                    isActive = c.IsActive
                })
                .ToListAsync();

            return Json(new
            {
                draw = draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FreeMaintenanceOfferForCreateDto dto)
        {
            var result = await _mediator.Send(new CreateFreeMaintenanceOfferCommand { Dto = dto });
            return StatusCode((int)result.Result.Code, result);
        }

        [HttpGet]
        public IActionResult UploadImage(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadFreeMaintenanceOfferImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadFreeMaintenanceOfferImageCommand { Dto = dto });
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
            var result = await _mediator.Send(new DeleteFreeMaintenanceOfferCommand { FreeMaintenanceOfferId = id });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return Json(new { id = id, message = "Deleted Successfully" });

        }

        [HttpPut]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var result = await _mediator.Send(new UpdateFreeMaintenanceOfferStatusCommand { OfferId = id });

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
