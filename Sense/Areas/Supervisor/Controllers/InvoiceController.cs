using Sense.Domain.Enums;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.UseCases.Invoice.Commands.CreateInvoiceCommand;
using Sense.Application.UseCases.Invoice.Queries.GetAllInvoicesByMaintenanceRecordIdQuery;
using Sense.Application.UseCases.MaintenanceRecord.Commands.CompleteMaintenanceRecordCommand;
using Sense.Application.UseCases.Supervisor.Commands.LogSupervisorActivityCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Sense.Areas.Supervisor.Controllers
{
    [Area("Supervisor")]
    [Authorize(Roles = "Supervisor")]
    public class InvoiceController : Controller
    {
        private readonly IMediator _mediator;
        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoicesByMaintenanceRecord(int maintenanceRecordId)
        {
            var invoices = await _mediator.Send(new GetAllInvoicesByMaintenanceRecordIdQuery { MaintenanceRecordId = maintenanceRecordId });

            return Json(invoices.Data);
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody] InvoiceForCreateDto dto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
                return Json(new { success = false });

            var result = await _mediator.Send(new CreateInvoiceCommand { Dto = dto });
            var log = await _mediator.Send(new LogSupervisorActivityCommand { CurrentUserId = userId, Dto = new SupervisorActivityLogForCreateDto { ActivityType = ActivityType.CreatedInvoice, Description = $"قمت بإضافة فاتورة # {dto.InvoiceNo} على سجل الصيانة" } });

            if (result.Result.Code == ResultCodeStatus.Created)
                return Json(new { success = true });


            return Json(new { success = false , message = result.Result.Message});

        }


        [HttpPost]
        public async Task<IActionResult> SaveLaborCosts(int maintenanceRecordId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new CompleteMaintenanceRecordCommand {  MaintenanceRecordId = maintenanceRecordId });
            if (result.Result.Code != ResultCodeStatus.Created)
                return Json(new { success = false });
            var log = await _mediator.Send(new LogSupervisorActivityCommand { CurrentUserId = userId, Dto = new SupervisorActivityLogForCreateDto { ActivityType = ActivityType.CompleteMaintenanceRecord, Description = $"قمت بمراجعة الفواتير وإكمال سجل الصيانة # {result?.Data?.Id}" } });
            return Json(new { success = true });
        }
    }
}
