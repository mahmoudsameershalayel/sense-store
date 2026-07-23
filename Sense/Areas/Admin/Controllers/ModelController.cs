using Sense.Domain.Enums;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.ModelDTOs;
using Sense.Application.UseCases.Brand.Commands.CreateBrandCommand;
using Sense.Application.UseCases.Brand.Commands.DeleteBrandCommand;
using Sense.Application.UseCases.Brand.Commands.UpdateBrandCommand;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.Model.Commands.CreateModelCommand;
using Sense.Application.UseCases.Model.Commands.DeleteModelCommand;
using Sense.Application.UseCases.Model.Commands.UpdateModelCommand;
using Sense.Application.UseCases.Model.Queries.GetAllModelsQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class ModelController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetAllModelsQuery { };
            var result = await _mediator.Send(query);
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            var items = result.Data;
            ViewBag.Brands = brands.Data;
            ViewBag.ActiveMenu = "Model";
            ViewData["title"] = "الموديلات";
            return View(items);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            ViewBag.Brands = brands.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ModelForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new CreateModelCommand { Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpPut("/Admin/Model/Edit/{modelId}")]
        public async Task<IActionResult> Edit(int modelId, [FromBody] ModelForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var command = new UpdateModelCommand { ModelId = modelId, Dto = dto };
            var result = await _mediator.Send(command);

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return Ok(new { id = modelId, message = "Updated Successfully" });
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteModelCommand { ModelId = id });

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
