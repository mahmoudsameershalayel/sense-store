using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Address.Commands.CreateAddressCommand;
using Sense.Application.UseCases.Address.Commands.DeleteAddressCommand;
using Sense.Application.UseCases.Address.Queries.GetAddressByIdQuery;
using Sense.Application.UseCases.Address.Queries.GetMyAllAddressesQuery;
using Sense.Application.UseCases.Brand.Commands.DeleteBrandCommand;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using Sense.Application.UseCases.Product.Queries.GetAllProductsQuery;
using Sense.Application.UseCases.Product.Queries.GetProductByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sense.Controllers
{
    public class AddressController : Controller
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> GetMyAddresses()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new GetMyAllAddressesQuery { CurrentUserId = currentUserId });
            return Ok(result.Data);
        }

        public IActionResult GetAddressModalPartial()
        {
            return PartialView("PartialViews/_AddressModal");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddressForCreateDto dto)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new CreateAddressCommand { Dto = dto, CurrentUserId = userId });

            if (result.Result.Code != ResultCodeStatus.BadRequest)
            {
                return Json(new
                {
                    success = true,
                    data = result.Data,   // this is what your JS expects
                    message = result.Result.Message
                });
            }

            return Json(new
            {
                success = false,
                message = result.Result.Message
            });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
           
            var result = await _mediator.Send(new GetAddressByIdQuery {  Id = id });

            return View(result.Data);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new DeleteAddressCommand {CurrentUserId = currentUserId , Id = id });

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
