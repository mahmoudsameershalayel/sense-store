using Sense.Application.RequestFeatures;
using Sense.Domain;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AppointmentDTOs;
using Sense.Infrastructure.Extensions;
using Sense.Application.UseCases.Appointment.Commands.AssignAppointmentCommand;
using Sense.Application.UseCases.Appointment.Commands.CancelAppointmentCommand;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsQuery;
using Sense.Application.UseCases.Appointment.Queries.GetAppointmentByIdQuery;
using Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.Service.Queries.GetAllServicesQuery;
using Sense.Application.UseCases.Supervisor.Queries.GetAllSupervisorsByBranchIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Sense.Areas.Admin.Controllers
{
    public class AppointmentController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator )
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(AppointmentParameters? appointmentParameters)
        {
            var appointments = await _mediator.Send(new GetAllAppointmentsQuery { AppointmentParameters = appointmentParameters });
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
            // قيم DataTables الأساسية
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            // الفلاتر المخصصة
            var serviceType = Request.Form["ServiceType"].FirstOrDefault();
            var status = Request.Form["Status"].FirstOrDefault();
            var brandId = Request.Form["BrandId"].FirstOrDefault();

            var result = await _mediator.Send(new LoadAppointmentsQuery { });
            var query = result.Data;

            // تطبيق الفلاتر
            if (!string.IsNullOrEmpty(serviceType))
                query = query.Where(a => a.ServiceId.ToString() == serviceType);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(a => ((int)a.Status).ToString() == status);

            if (!string.IsNullOrEmpty(brandId))
                query = query.Where(a => a.BrandId.ToString() == brandId);

            // البحث العام
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(a =>
                    a.Brand.Name.Contains(searchValue) ||
                    a.Model.Name.Contains(searchValue) ||
                    a.Id.ToString().Contains(searchValue));
            }

            var recordsTotal = await query.CountAsync();

            // التصفح (Pagination)
            var data = await query
                .OrderByDescending(a => a.CreatedAt)
                .Skip(start)
                .Take(length)
                .Select(a => new {
                    id = $"{a.Id}#" ,
                    brand = a.Brand.Name,
                    model = a.Model.Name,
                    modelYear = a.ModelYear,
                    service = a.Service.TitleAr,
                    createdAtDate = a.CreatedAt.Value.ToString("yyyy-MM-dd"),
                    scheduledDate = a.ScheduledDate.Value.ToString("yyyy-MM-dd") ?? "لم يحدد",
                    scheduledTime = a.ScheduledDate.Value.ToString("HH:mm tt") ?? "لم يحدد",
                    branch = a.Branch.BranchName ?? "لم يتم التعيين",
                    customerApplicationUserId = a.Customer.ApplicationUserId, // Add this line
                    status = $"<span class='badge {(a.Status == AppointmentStatus.Completed ? "badge-light-success" :
                                    a.Status == AppointmentStatus.Pending ? "badge-light-warning" :
                                    a.Status == AppointmentStatus.Scheduled ? "badge-light-primary" :
                                    a.Status == AppointmentStatus.Canceled ? "badge-light-danger" :
                                    a.Status == AppointmentStatus.Rejected ? "badge-light-danger" :
                                    a.Status == AppointmentStatus.Accepted ? "badge-light-info" :
                                    "badge-light-info")} fs-7 fw-bold'>{a.Status.GetDisplayName()}</span>"
                })
                .ToListAsync();

            // إعادة النتائج إلى DataTables
            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetSupervisorsByBranch(int branchId)
        {
            var result = await _mediator.Send(new GetAllSupervisorsByBranchIdQuery { BranchId = branchId });
            var supervisors = result.Data.Select(s => new { id = s.Id, name = s.FullName }).ToList();

            return Json(supervisors);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {                                                       
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointment = await _mediator.Send(new GetAppointmentByIdQuery { AppointmentId = id , CurrentUserId = userId }); 

            return View(appointment.Data); 
        }

        [HttpPut]
        public async Task<IActionResult> AssignAppointment([FromBody] AssignAppointmentDto dto)
        {
            var result = await _mediator.Send(new AssignAppointmentCommand { Dto = dto });
            if (result.Result.Code == ResultCodeStatus.Success)
                return Json(new { success = true });

            return Json(new { success = false, message = result.Result.Message });
        }

        [HttpPut]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new CancelAppointmentCommand { CurrentUserId = userId , AppointmentId = id});

            if (result.Result.Code == ResultCodeStatus.Success)
                return Json(new { success = true });

            return Json(new { success = false, message = result.Result.Message });
        }
    }
}
