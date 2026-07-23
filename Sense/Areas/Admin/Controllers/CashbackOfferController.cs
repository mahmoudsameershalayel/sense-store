using Sense.Domain.Enums;
using Sense.Application.DTOs.CashbackOfferDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using Sense.Infrastructure.Extensions;
using Sense.Application.UseCases.CashbackOffer.Commands.DeleteCashbackOfferCommand;
using Sense.Application.UseCases.OfferCashback.Commands.CreateCashbackOfferCommand;
using Sense.Application.UseCases.CashbackOffer.Commands.UpdateCashbackOfferStatusCommand;
using Sense.Application.UseCases.CashbackOffer.Commands.UploadCashbackOfferImageCommand;
using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using Sense.Application.UseCases.CashbackOffer.Queries.LoadCashbackOffersQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Areas.Admin.Controllers
{
    public class CashbackOfferController : AdminBaseController
    {
        private readonly IMediator _mediator;

        public CashbackOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllCashbackOffersQuery { };
            var result = await _mediator.Send(query);
            ViewBag.ActiveMenu = "CashbackOffer";
            ViewData["title"] = "ÚÑæÖ ÇáßÇÔ ÈÇß";
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> LoadCashbackOffers()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");

            // Get your cashback offers query from database/service
            var result = await _mediator.Send(new LoadCashbackOffersQuery());
            var query = result.Data;
            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderBy(c => c.Id)
                .Skip(start)
                .Take(length)
                .Select(c => new
                {
                    id = c.Id,
                    imageURL = c.ImageURL,
                    cashbackVal = c.CashbackVal,
                    cashbackType = c.CashbackType.GetDisplayName(),
                    returnType = c.ReturnType.GetDisplayName(),
                    isApplyOnSparePart = c.IsApplyOnSparePart,
                    isApplyOnLaborCost = c.IsApplyOnLaborCost,
                    isApplyOnStore = c.IsApplyOnStore,
                    startDate = c.StartDate.Value.ToString("yyyy-MM-dd"),
                    endDate = c.EndDate.Value.ToString("yyyy-MM-dd"),
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
        public async Task<IActionResult> Add([FromBody] CashbackOfferForCreateDto dto)
        {
            var result = await _mediator.Send(new CreateCashbackOfferCommand { Dto = dto });
            return StatusCode((int)result.Result.Code, result);
        }

        [HttpGet]
        public IActionResult UploadImage(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadCashbackOfferImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadCashbackOfferImageCommand { Dto = dto });
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
            var result = await _mediator.Send(new DeleteCashbackOfferCommand { CashbackOfferId = id });

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
            var result = await _mediator.Send(new UpdateCashbackOfferStatusCommand { OfferId = id });

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
