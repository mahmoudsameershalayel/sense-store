using Sense.Domain.Enums;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Banner.Commands.CreateBannerCommand;
using Sense.Application.UseCases.Branch.Commands.UpdateBranchCommand;
using Sense.Application.UseCases.Brand.Commands.CreateBrandCommand;
using Sense.Application.UseCases.Brand.Commands.DeleteBrandCommand;
using Sense.Application.UseCases.Brand.Commands.UpdateBrandCommand;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.Brand.Queries.GetBrandByIdQuery;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class BrandController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetAllBrandsQuery { };
            var result = await _mediator.Send(query);
            var items = result.Data;
            ViewBag.ActiveMenu = "Brand";
            ViewData["title"] = "البراندات";
            return View(items);
        }
        [HttpGet]
        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(BrandForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new CreateBrandCommand { Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpPut("/Admin/Brand/Edit/{BrandId}")]
        public async Task<IActionResult> Edit(int BrandId , [FromBody] BrandForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var command = new UpdateBrandCommand {BrandId = BrandId , Dto = dto };
            var result = await _mediator.Send(command);

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return Ok(new { id = BrandId, message = "Updated Successfully" });
        }


       
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBrandCommand { BrandId = id });

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
