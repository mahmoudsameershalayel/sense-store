using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using Sense.Infrastructure.Extensions;
using Sense.Application.UseCases.Appointment.Commands.CancelAppointmentCommand;
using Sense.Application.UseCases.Appointment.Commands.CompleteAppointmentCommand;
using Sense.Application.UseCases.Appointment.Commands.ReceiveAppointmentCommand;
using Sense.Application.UseCases.Appointment.Commands.RejectAppointmentCommand;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsBySupervisorIdQuery;
using Sense.Application.UseCases.Appointment.Queries.GetAppointmentByIdQuery;
using Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.Service.Queries.GetAllServicesQuery;
using Sense.Application.UseCases.Supervisor.Commands.LogSupervisorActivityCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Sense.Areas.Supervisor.Controllers
{
    public class AppointmentController : SupervisorBaseController
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(AppointmentParameters? appointmentParameters)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var appointments = await _mediator.Send(new GetAllAppointmentsBySupervisorIdQuery { AppointmentParameters = appointmentParameters, CurrentUserId = currentUserId });
            var brands = await _mediator.Send(new GetAllBrandsQuery { });
            var branches = await _mediator.Send(new GetAllBranchesQuery { });
            var services = await _mediator.Send(new GetAllServicesQuery { });

            ViewBag.Brands = brands.Data;
            ViewBag.Branches = branches.Data;
            ViewBag.Services = services.Data;

            ViewBag.TotalPages = appointments.Data.MetaData.TotalPages;
            ViewBag.CurrentPage = appointments.Data.MetaData.CurrentPage;

            ViewBag.ActiveMenu = "Appointments";
            ViewData["title"] = "الحجوزات";


            return View(appointments.Data);
        }

        [HttpPost]
        public async Task<IActionResult> LoadAppointments()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            var serviceType = Request.Form["ServiceType"].FirstOrDefault();
            var status = Request.Form["Status"].FirstOrDefault();

            var result = await _mediator.Send(new LoadAppointmentsQuery { CurrentUserId = currentUserId });
            var query = result.Data;

            if (!string.IsNullOrEmpty(serviceType))
            {
                var serviceId = int.Parse(serviceType);
                query = query.Where(a => a.ServiceId == serviceId);
            }

            if (!string.IsNullOrEmpty(status))
            {
                var statusValue = int.Parse(status);
                query = query.Where(a => (int)a.Status == statusValue);
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(a =>
                    a.Brand.Name.Contains(searchValue) ||
                    a.Model.Name.Contains(searchValue) ||
                    a.Id.ToString().Contains(searchValue));
            }

            var recordsTotal = await query.CountAsync();

            var data = await query
                .OrderByDescending(a => a.CreatedAt)
                .Skip(start)
                .Take(length)
                .Select(a => new
                {
                    id = a.Id,
                    modelYear = a.ModelYear,
                    brand = a.Brand.Name,
                    service = a.Service.TitleAr,
                    createdAtDate = a.CreatedAt.Value.ToString("yyyy-MM-dd"),
                    scheduledDate = a.ScheduledDate.Value.ToString("yyyy-MM-dd"),
                    scheduledTime = a.ScheduledDate.Value.ToString("HH:mm tt"),
                    branch = a.Branch.BranchName ?? "لم يتم التعيين",
                    status = $"<span class='badge {(a.Status == AppointmentStatus.Completed ? "badge-light-success" :
                                    a.Status == AppointmentStatus.Pending ? "badge-light-warning" :
                                    a.Status == AppointmentStatus.Scheduled ? "badge-light-primary" :
                                    a.Status == AppointmentStatus.Canceled ? "badge-light-danger" :
                                    a.Status == AppointmentStatus.Rejected ? "badge-light-danger" :
                                    a.Status == AppointmentStatus.Accepted ? "badge-light-info" :
                                    "badge-light-info")} fs-7 fw-bold'>{a.Status.GetDisplayName()}</span>"
                })
                .ToListAsync();

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _mediator.Send(new GetAppointmentByIdQuery { AppointmentId = id, CurrentUserId = userId });

            return View(appointment.Data);
        }


        [HttpPut]
        public async Task<IActionResult> RejectAppointment(RejectAppointmentDto dto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new RejectAppointmentCommand { Dto = dto, CurrentUserId = userId });
            var log = await _mediator.Send(new LogSupervisorActivityCommand { CurrentUserId = userId, Dto = new SupervisorActivityLogForCreateDto { ActivityType = ActivityType.RejecteAppointment, Description =  $"قمت برفض إستلام السيارة لأن : {dto.RejectReason}" } });
            return StatusCode((int)result.Result.Code, result.Data);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ReceiveAppointment(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new ReceiveAppointmentCommand { CurrentUserId = userId, AppointmentId = id });
            var log = await _mediator.Send(new LogSupervisorActivityCommand { CurrentUserId = userId, Dto = new SupervisorActivityLogForCreateDto { ActivityType = ActivityType.ReceiveAppointment, Description = "قمت بإستلام السيارة" } });
            return StatusCode((int)result.Result.Code, result.Data);
        }

        [HttpPut]
        public async Task<IActionResult> CompleteAppointment(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new CompleteAppointmentCommand { AppointmentId = id });
            var log = await _mediator.Send(new LogSupervisorActivityCommand { CurrentUserId = userId, Dto = new SupervisorActivityLogForCreateDto { ActivityType = ActivityType.CompleteAppointment, Description = "قمت بإكمال الحجز" } });
            return StatusCode((int)result.Result.Code, result.Data);
        }

    }
}
