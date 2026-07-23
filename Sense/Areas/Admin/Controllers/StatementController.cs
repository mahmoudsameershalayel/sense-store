using Sense.Domain.Enums;
using Sense.Application.DTOs.StatementDTOs;
using Sense.Application.UseCases.Statement.Commands.CreateStatementCommand;
using Sense.Application.UseCases.Statement.Commands.DeleteStatementCommand;
using Sense.Application.UseCases.Statement.Commands.UpdateStatementCommand;
using Sense.Application.UseCases.Statement.Commands.UpdateStatementStatusCommand;
using Sense.Application.UseCases.Statement.Queries.GetAllStatementsQuery;
using Sense.Application.UseCases.Statement.Queries.GetStatementByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class StatementController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public StatementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllStatementsQuery { });
            var items = result.Data;
            ViewBag.ActiveMenu = "Statement";
            ViewData["title"] = "عبارات الثقة";
            return View(items);
        }

        [HttpGet]
        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(StatementForCreateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new CreateStatementCommand { Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _mediator.Send(new GetStatementByIdQuery { StatementId = id });
            if (result.Data is null)
                return RedirectToAction(nameof(Index));

            var dto = new StatementForUpdateDto
            {
                Id = result.Data.Id,
                Text = result.Data.Text,
                IconClass = result.Data.IconClass,
                SortOrder = result.Data.SortOrder
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StatementForUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.Id = id;
            var result = await _mediator.Send(new UpdateStatementCommand { Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpPut]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var result = await _mediator.Send(new UpdateStatementStatusCommand { StatementId = id });

            if (result.Result.Code != ResultCodeStatus.Success)
                return Json(new { success = false, message = result.Result.Message });

            return Json(new { success = true, id = id, message = result.Result.Message });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStatementCommand { StatementId = id });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return Json(new { success = false, message = result.Result.Message });
            }
            TempData["Message"] = result.Result.Message;
            return Json(new { success = true, message = result.Result.Message });
        }
    }
}
