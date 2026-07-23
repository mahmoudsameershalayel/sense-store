using Sense.Domain.Enums;
using Sense.Application.DTOs.CouponDTOs;
using Sense.Application.UseCases.Coupon.Commands.CreateCouponCommand;
using Sense.Application.UseCases.Coupon.Commands.DeleteCouponCommand;
using Sense.Application.UseCases.Coupon.Commands.UpdateCouponCommand;
using Sense.Application.UseCases.Coupon.Commands.UpdateCouponStatusCommand;
using Sense.Application.UseCases.Coupon.Queries.GetAllCouponsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class CouponController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public CouponController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetAllCouponsQuery { };
            var result = await _mediator.Send(query);
            var items = result.Data;
            ViewBag.ActiveMenu = "Coupon";
            ViewData["title"] = "كوبونات الخصم";
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CouponForCreateDto dto)
        {
            var result = await _mediator.Send(new CreateCouponCommand { Dto = dto });
            return StatusCode((int)result.Result.Code, result);
        }
       
      

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]CouponForUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var command = new UpdateCouponCommand { Dto = dto };
            var result = await _mediator.Send(command);

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return Ok(new { id = dto.Id, message = "Updated Successfully" });
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCouponCommand { CouponId = id });

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
            var result = await _mediator.Send(new UpdateCouponStatusCommand { CouponId = id });

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
