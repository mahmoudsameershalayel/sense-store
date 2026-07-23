using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Application.UseCases.ActivityLog.Commands.LogSupervisorActivityCommand;
using Sense.Application.UseCases.Appointment.Commands.BookAppointmentCommand;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsQuery;
using Sense.Application.UseCases.Appointment.Queries.GetAppointmentByIdQuery;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sense.Controllers
{
    [Authorize(Roles = "Customer")]
    public class AppointmentController : Controller
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyAppointments()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> BookAppointment([FromBody]AppointmentForCreateDto dto)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new BookAppointmentCommand {CurrentUserId = userId , Dto = dto });
            var resultBrands = await _mediator.Send(new GetAllBrandsQuery() { });
            ViewBag.Brands = resultBrands.Data;
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return Json(new
                {
                    success = false,
                    message = result.Result.Message
                });
            }
            var log = await _mediator.Send(new LogCustomerActivityCommand { CurrentUserId = userId, Dto = new CustomerActivityLogForCreateDto { ActivityType = CustomerActivityType.BookAppointment, Description = $"قمت بحجز موعد برقم : {result.Data.Id}#" } });
            TempData["Message"] = result.Result.Message;
            return Json(new { success = true, message = result.Result.Message });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _mediator.Send(new GetAppointmentByIdQuery { AppointmentId = id, CurrentUserId = userId });
            return View(appointment.Data);
        }

        public async Task<PartialViewResult> GetAppointmentsTable(AppointmentParameters appointmentParameters)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointments = await _mediator.Send(new GetAllAppointmentsQuery { AppointmentParameters = appointmentParameters, CurrentUserId = userId });
            return PartialView("_AppointmentsTableRows", appointments.Data);
        }
    }
}
