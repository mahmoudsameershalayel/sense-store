using Sense.Application.RequestFeatures;
using Sense.Infrastructure.Extensions;
using Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordsQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetMaintenanceRecordQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.LoadMaintenanceRecordQuery;
using Sense.Application.UseCases.Supervisor.Queries.GetAllSupervisorsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Areas.Admin.Controllers
{
    public class MaintenanceRecordController : AdminBaseController
    {
        private readonly IMediator _mediator;

        public MaintenanceRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(MaintenanceRecordParameters? maintenanceRecordParameters)
        {
            var maintenanceRecords = await _mediator.Send(new GetAllMaintenanceRecordsQuery { maintenanceRecordParameters = maintenanceRecordParameters });

            var supervisors = await _mediator.Send(new GetAllSupervisorsQuery());

            ViewBag.Supervisors = supervisors.Data;

            ViewBag.TotalPages = maintenanceRecords.Data.MetaData.TotalPages;
            ViewBag.CurrentPage = maintenanceRecords.Data.MetaData.CurrentPage;

            ViewBag.ActiveMenu = "MaintenanceRecords";
            ViewData["title"] = "سجلات الصيانة";


            return View(maintenanceRecords.Data);
        }

        [HttpPost]
        public async Task<IActionResult> LoadMaintenanceRecords()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");

            var supervisorId = Request.Form["SupervisorId"].FirstOrDefault();
            var startDate = Request.Form["StartDate"].FirstOrDefault();
            var endDate = Request.Form["EndDate"].FirstOrDefault();
            var invoiceNo = Request.Form["InvoiceNo"].FirstOrDefault();

            var result = await _mediator.Send(new LoadMaintenanceRecordQuery { });
            var query = result.Data;

            if (!string.IsNullOrEmpty(supervisorId))
                query = query.Where(x => x.SupervisorId.ToString() == supervisorId);
            if (DateTime.TryParse(startDate, out var sDate) && DateTime.TryParse(endDate, out var eDate))
            {
                query = query.Where(x => x.StartDate.HasValue
                                         && x.StartDate.Value.Date >= sDate.Date
                                         && x.StartDate.Value.Date <= eDate.Date);
            }
            else if (DateTime.TryParse(startDate, out sDate))
            {
                query = query.Where(x => x.StartDate.HasValue && x.StartDate.Value.Date >= sDate.Date);
            }
            else if (DateTime.TryParse(endDate, out eDate))
            {
                query = query.Where(x => x.StartDate.HasValue && x.StartDate.Value.Date <= eDate.Date);
            }


            if (!string.IsNullOrEmpty(invoiceNo))
            {
                // تأكد أن MaintenanceRecord يحتوي على Invoices
                query = query.Where(x => x.Invoices.Any(i => i.InvoiceNo.ToString().Equals(invoiceNo)));
            }

            var totalRecords = await query.CountAsync();
                                                                                        
            var data = await query
                .OrderByDescending(x => x.StartDate)
                .Skip(start)
                .Take(length)
                .Select(x => new
                {
                    id = x.Id,
                    customerName = $"{x.Appointment.Customer.ApplicationUser.FirstName} {x.Appointment.Customer.ApplicationUser.LastName}",
                    supervisorName = $"{x.Appointment.Supervisor.ApplicationUser.FirstName} {x.Appointment.Supervisor.ApplicationUser.LastName}",
                    startDate = x.StartDate.Value.ToString("yyyy-MM-dd"),
                    startTime = x.StartDate.Value.ToString("HH:mm"),
                    endDate = x.EndDate.Value.ToString("yyyy-MM-dd") ?? "لم تنتهي الصيانة",
                    endTime = x.EndDate.Value.ToString("HH:mm") ?? "لم تنتهي الصيانة",
                    status = BadgeHelper.GetMaintenanceRecordStatus(x.Status)
                })
                .ToListAsync();

            return Json(new
            {
                draw = draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = data
            });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var query = new GetMaintenanceRecordQuery() { MaintenanceRecordId = id };
            var result = await _mediator.Send(query);
            return View(result.Data);
        }

    }
}
