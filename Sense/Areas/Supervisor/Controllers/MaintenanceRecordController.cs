using Sense.Application.RequestFeatures;
using Sense.Infrastructure.Extensions;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllSupervisorsQuery;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsBySupervisorIdQuery;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordBySupervisorIdQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordsQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetMaintenanceRecordQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.LoadMaintenanceRecordQuery;
using Sense.Application.UseCases.Product.Queries.GetAllProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace SenseWeb.Areas.Supervisor.Controllers
{
    [Area("Supervisor")]
    [Authorize(Roles = "Supervisor")]
    public class MaintenanceRecordController : Controller
    {
        private readonly IMediator _mediator;

        public MaintenanceRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(MaintenanceRecordParameters? maintenanceRecordParameters)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var maintenanceRecords = await _mediator.Send(new GetAllMaintenanceRecordBySupervisorIdQuery { MaintenanceRecordParameters = maintenanceRecordParameters, CurrentUserId = currentUserId });
            var products = await _mediator.Send(new GetAllProductsQuery { ProductParameters = new ProductParameters() });

            ViewBag.Products = products.Data;

            ViewBag.TotalPages = maintenanceRecords.Data.MetaData.TotalPages;
            ViewBag.CurrentPage = maintenanceRecords.Data.MetaData.CurrentPage;

            ViewBag.ActiveMenu = "MaintenanceRecords";
            ViewData["title"] = "”Ã·«  «·’Ì«‰…";


            return View(maintenanceRecords.Data);
        }


        [HttpPost]
        public async Task<IActionResult> LoadMaintenanceRecords()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");

            var startDate = Request.Form["StartDate"].FirstOrDefault();
            var endDate = Request.Form["EndDate"].FirstOrDefault();
            var invoiceNo = Request.Form["InvoiceNo"].FirstOrDefault();

            var result = await _mediator.Send(new LoadMaintenanceRecordQuery {CurrentUserId = currentUserId });
            var query = result.Data;

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
                //  √ﬂœ √‰ MaintenanceRecord ÌÕ ÊÌ ⁄·Ï Invoices
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
                    supervisorName = $"{x.Supervisor.ApplicationUser.FirstName} {x.Supervisor.ApplicationUser.LastName}",
                    startDate = x.StartDate.Value.ToString("yyyy-MM-dd"),
                    startTime = x.StartDate.Value.ToString("HH:mm"),
                    endDate = x.EndDate.Value.ToString("yyyy-MM-dd") ?? "·„  ‰ ÂÌ «·’Ì«‰…",
                    endTime = x.EndDate.Value.ToString("HH:mm") ?? "·„  ‰ ÂÌ «·’Ì«‰…",
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
            var setting = await _mediator.Send(new GetCenterSettingQuery() { });
            var query = new GetMaintenanceRecordQuery() { MaintenanceRecordId = id };
            var result = await _mediator.Send(query);

            ViewBag.Setting = setting.Data;

            return View(result.Data);
        }

     

        private string GetPaymentStatusBadge(string status)
        {
            return status.ToLower() switch
            {
                "paid" => "Paid",
                "pending" => "Pending",
                "failed" => "Failed",
                _ => "Unknown"
            };
        }
    }
}
