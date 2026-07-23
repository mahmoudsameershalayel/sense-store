using Sense.Domain.Enums;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.UploadCategoryImageCommand;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using Sense.Application.UseCases.Product.Commands.UploadProductImageCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace Sense.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetAllCategoriesQuery { };
            var result = await _mediator.Send(query);
            var items = result.Data;
			ViewBag.ActiveMenu = "Category";
			ViewData["title"] = "الأصناف";
            return View(items);
        }
        [HttpGet]
        public IActionResult Add()
            => View();
       
        [HttpPost]
        public async Task<IActionResult> Add(CategoryForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new CreateCategoryCommand { Dto = dto });

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
        public async Task<IActionResult> UploadImage(UploadCategoryImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadCategoryImageCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction("Index");
        }



        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CategoryForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var command = new UpdateCategoryCommand { Dto = dto };
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
            var result = await _mediator.Send(new DeleteCategoryCommand { CategoryId = id });

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
