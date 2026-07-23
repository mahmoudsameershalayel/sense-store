using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.UseCases.ActivityLog.Queries.GenerateCustomerReportQuery;
using Sense.Application.UseCases.ApplicationUser.Commands.CreateUserCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserAccountStatusCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UploadUserImageCommand;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllCustomersQuery;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllUsersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class ApplicationUserController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(UserParameters? userParameters)
        {
            var result = await _mediator.Send(new GetAllCustomersQuery { UserParameters = userParameters });
            var items = result.Data;

            ViewBag.CurrentPage = userParameters.PageNumber;
            ViewBag.PageSize = userParameters.PageSize;
            ViewBag.SearchTerm = userParameters.Name;
            ViewBag.TotalPages = result.Data.MetaData.TotalPages;

            ViewBag.ActiveMenu = "Customers";
            ViewData["title"] = "العملاء";
            return View(items);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserForRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new CreateUserCommand {UserType = UserType.Customer ,  Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> UpdateUserAccountStatus(string id)
        {
            var result = await _mediator.Send(new UpdateUserAccountStatusCommand { UserId = id });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return Json(new { id = id, message = "Updated Successfully" });

        }
        [HttpGet]
        public async Task<IActionResult> ActivityReport(string id)
        {
            var result = await _mediator.Send(new GenerateCustomerReportQuery { CustomerId = id });
            return View(result.Data);
        }

        /*
     [HttpGet]
     public async Task<IActionResult> Edit(int id)
     {
         var query = new GetProductByIdQuery { ProductId = id };
         var result = await _mediator.Send(query);
         return View(result.Data);
     }
     [HttpPost]
     public async Task<IActionResult> Edit(int productId, ProductForCreateUpdateDto dto)
     {
         if (!ModelState.IsValid)
             return View();

         var result = await _mediator.Send(new UpdateProductCommand { ProductId = productId, Dto = dto });
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
         var result = await _mediator.Send(new DeleteProductCommand { ProductId = id });

         if (result.Result.Code != ResultCodeStatus.Success)
         {
             TempData["ErrorMessage"] = result.Result.Message;
             return RedirectToAction(nameof(Index));
         }
         TempData["Message"] = result.Result.Message;
         return Json(new { id = id, message = "Deleted Successfully" });

     }
        */
    }
}
