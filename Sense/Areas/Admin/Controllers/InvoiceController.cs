using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Infrastructure.Extensions;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllUsersQuery;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Application.UseCases.Invoice.Commands.UpdateInvoiceCommand;
using Sense.Application.UseCases.Invoice.Queries.GetInvoiceByIdQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.LoadInvoicesQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.LoadMaintenanceRecordQuery;
using Sense.Application.UseCases.Supervisor.Queries.GetAllSupervisorsQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Areas.Admin.Controllers
{
    public class InvoiceController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var supervisors = await _mediator.Send(new GetAllSupervisorsQuery());

            ViewBag.Supervisors = supervisors.Data;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var result = await _mediator.Send(new LoadInvoicesQuery { });
            var invoice = await result.Data
                .Include(x => x.Order).ThenInclude(o => o.OrderDetails).ThenInclude(d => d.Product)
                .Include(x => x.Order).ThenInclude(o => o.Address)
                .FirstOrDefaultAsync(x => x.InvoiceNo == id);

            if (invoice is null)
            {
                TempData["ErrorMessage"] = "الفاتورة غير موجودة";
                return RedirectToAction(nameof(Index));
            }

            var setting = await _mediator.Send(new GetCenterSettingQuery());
            ViewBag.Setting = setting.Data;

            return View(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> LoadInvoices()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");

            var supervisorId = Request.Form["SupervisorId"].FirstOrDefault();
            var startDate = Request.Form["StartDate"].FirstOrDefault();
            var endDate = Request.Form["EndDate"].FirstOrDefault();
            var invoiceNo = Request.Form["InvoiceNo"].FirstOrDefault();
            var invoiceType = Request.Form["InvoiceType"].FirstOrDefault();

            var result = await _mediator.Send(new LoadInvoicesQuery { });
            var query = result.Data;

           

            if (!string.IsNullOrEmpty(invoiceType) && Enum.TryParse<InvoiceType>(invoiceType, out var parsedType))
            {
                query = query.Where(x => x.InvoiceType == parsedType);
            }

           

            if (DateTime.TryParse(startDate, out var sDate) && DateTime.TryParse(endDate, out var eDate))
            {
                query = query.Where(x => x.CreatedAt.HasValue
                                         && x.CreatedAt.Value.Date >= sDate.Date
                                         && x.CreatedAt.Value.Date <= eDate.Date);
            }
            else if (DateTime.TryParse(startDate, out sDate))
            {
                query = query.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Date >= sDate.Date);
            }
            else if (DateTime.TryParse(endDate, out eDate))
            {
                query = query.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Date <= eDate.Date);
            }


            if (!string.IsNullOrEmpty(invoiceNo))
            {
                query = query.Where(x => x.InvoiceNo.ToString().Contains(invoiceNo));
            }

            if (!string.IsNullOrEmpty(supervisorId) && int.TryParse(supervisorId, out var supId))
            {
                query = query.Where(x => x.MaintenanceRecord != null && x.MaintenanceRecord.SupervisorId == supId);
            }

            var recordsFiltered = await query.CountAsync();

            decimal supervisorTotal = 0;
            int supervisorCount = 0;

            if (!string.IsNullOrEmpty(supervisorId) && int.TryParse(supervisorId, out var supervisorIdInt))
            {
                var supervisorQuery = query.Where(x => x.MaintenanceRecord != null && x.MaintenanceRecord.SupervisorId == supervisorIdInt);
                supervisorTotal = await supervisorQuery.SumAsync(x => x.InvoiceAmount);
                supervisorCount = await supervisorQuery.CountAsync();
            }

            var data = await query.Skip(start).Take(length)
                .Select(x => new
                {
                    id = x.InvoiceNo,
                    orderNo = x.OrderId.HasValue ? x.OrderId.Value.ToString() : "-",
                    customerName = x.Order != null
                        ? $"{x.Order.Customer.ApplicationUser.FirstName} {x.Order.Customer.ApplicationUser.LastName}"
                        : $"{x.MaintenanceRecord.Appointment.Customer.ApplicationUser.FirstName} {x.MaintenanceRecord.Appointment.Customer.ApplicationUser.LastName}",
                    supervisorName = x.MaintenanceRecord != null
                        ? $"{x.MaintenanceRecord.Supervisor.ApplicationUser.FirstName} {x.MaintenanceRecord.Supervisor.ApplicationUser.LastName}"
                        : "طلب متجر",
                    invoiceType = x.InvoiceType != null ? x.InvoiceType.Value.GetDisplayName() : "",
                    invoiceAmount = x.InvoiceAmount.ToString("N2") + "                         <svg class='riyal-svg currency' fill='currentColor' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 78.917 78.917' width='15' height='15' aria-hidden='true' focusable='false' style='display:inline-block;vertical-align:-0.125em'><path d='M32.501,16.458H9.021L9,66.958c0,2.48-2.019,4.5-4.5,4.5s-4.5-2.02-4.5-4.5l0.025-55.005c0.003-2.479,2.021-4.495,4.5-4.495h27.977c13.51,0,24.5,10.991,24.5,24.5v23c0,2.48-2.02,4.5-4.5,4.5s-4.5-2.02-4.5-4.5v-23C48.001,23.412,41.048,16.458,32.501,16.458z M74.417,7.458c-2.481,0-4.5,2.019-4.5,4.5l-0.021,50.5h-23.48c-8.547,0-15.5-6.953-15.5-15.5v-23c0-2.481-2.019-4.5-4.5-4.5s-4.5,2.019-4.5,4.5v23c0,13.509,10.99,24.5,24.5,24.5h27.977c2.479,0,4.498-2.016,4.5-4.495l0.024-55.005C78.917,9.478,76.898,7.458,74.417,7.458z' /></svg>",
                    date = x.CreatedAt.HasValue ? x.CreatedAt.Value.ToString("yyyy-MM-dd") : "غير محدد",
                    time = x.CreatedAt.HasValue ? x.CreatedAt.Value.ToString("HH:mm") : "غير محدد"
                })
                .ToListAsync();

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsFiltered,
                recordsTotal = await result.Data.CountAsync(),
                data = data,
                supervisorTotal = supervisorTotal.ToString("N2"),
                supervisorCount = supervisorCount
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var result = await _mediator.Send(new GetInvoiceByIdQuery { InvoiceNo = id });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                if (Request.Headers["Accept"].ToString().Contains("application/json"))
                {
                    return Json(new { success = false, message = result.Result.Message });
                }
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }

            if (Request.Headers["Accept"].ToString().Contains("application/json"))
            {
                // Return JSON for AJAX requests
                return Json(new
                {
                    invoiceNo = result.Data.InvoiceNo,
                    invoiceAmount = result.Data.InvoiceAmount,
                    invoiceType =(int)Enum.Parse<InvoiceType>(result.Data.InvoiceType)
                });
            }

            // Convert InvoiceDto to InvoiceForUpdateDto for the view
            var updateDto = new InvoiceForUpdateDto
            {
                InvoiceNo = result.Data.InvoiceNo,
                InvoiceAmount = result.Data.InvoiceAmount,
                InvoiceType = Enum.TryParse<InvoiceType>(result.Data.InvoiceType, out var invoiceType) ? invoiceType : null
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InvoiceForUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new UpdateInvoiceCommand { Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return View(dto);
            }

            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInvoiceAjax([FromBody] InvoiceForUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "البيانات غير صحيحة" });

            var result = await _mediator.Send(new UpdateInvoiceCommand { Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Success)
                return Json(new { success = false, message = result.Result.Message });

            return Json(new { success = true, message = result.Result.Message });
        }
    }
}
