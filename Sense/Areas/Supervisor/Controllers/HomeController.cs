using Sense.Application.RequestFeatures;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsBySupervisorIdQuery;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsQuery;
using Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordBySupervisorIdQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.LoadInvoicesQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.LoadMaintenanceRecordQuery;
using Sense.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sense.Areas.Supervisor.Controllers
{
    [Area("Supervisor")]
    [Authorize(Roles = "Supervisor")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var supervisorBookings = await _mediator.Send(new LoadAppointmentsQuery { CurrentUserId = currentUserId });
            var maintenanceRecords = await _mediator.Send(new LoadMaintenanceRecordQuery {  CurrentUserId = currentUserId });
            var invoices = await _mediator.Send(new LoadInvoicesQuery {  CurrentUserId = currentUserId });

            ViewBag.SupervisorBookings = supervisorBookings.Data?.Count();
            ViewBag.ScheduledBookings = supervisorBookings.Data?.Where(x => x.Status == Sense.Domain.Enums.AppointmentStatus.Scheduled).Count();
            ViewBag.MaintenanceRecords = maintenanceRecords.Data?.Count();
            ViewBag.Invoices = invoices.Data?.Count();

            return View();
        }
    }
}
