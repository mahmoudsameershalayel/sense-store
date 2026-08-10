using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ServiceListingDTOs;
using Sense.Application.UseCases.ServiceListing.Commands.ChangeServiceListingStatusCommand;
using Sense.Application.UseCases.ServiceListing.Commands.CreateServiceListingCommand;
using Sense.Application.UseCases.ServiceListing.Commands.DeleteServiceListingCommand;
using Sense.Application.UseCases.ServiceListing.Commands.UpdateServiceListingCommand;
using Sense.Application.UseCases.ServiceListing.Commands.UploadServiceListingImageCommand;
using Sense.Application.UseCases.ServiceListing.Queries.GetAllServiceListingsQuery;
using Sense.Application.UseCases.ServiceListing.Queries.LoadServiceListingsQuery;
using Sense.Application.UseCases.ServiceProvider.Queries.GetAllServiceProvidersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Areas.Admin.Controllers
{
    public class ServiceListingController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public ServiceListingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private static string BuildStatusBadge(ServiceListingStatus status)
            => status switch
            {
                ServiceListingStatus.Draft => "<span class='badge badge-light-secondary'>مسودة</span>",
                ServiceListingStatus.PendingReview => "<span class='badge badge-light-warning'>بإنتظار المراجعة</span>",
                ServiceListingStatus.Approved => "<span class='badge badge-light-info'>مقبولة</span>",
                ServiceListingStatus.Rejected => "<span class='badge badge-light-danger'>مرفوضة</span>",
                ServiceListingStatus.Published => "<span class='badge badge-light-success'>منشورة</span>",
                ServiceListingStatus.Unpublished => "<span class='badge badge-light-dark'>غير منشورة</span>",
                ServiceListingStatus.Archived => "<span class='badge badge-dark'>مؤرشفة</span>",
                _ => "<span class='badge badge-light'>-</span>"
            };
        public async Task<IActionResult> Index(ServiceListingParameters? serviceListingParameters)
        {
            var result = await _mediator.Send(new GetAllServiceListingsQuery { ServiceListingParameters = serviceListingParameters });

            var items = result.Data;

            ViewBag.ActiveMenu = "ServiceListing";
            ViewData["title"] = "الخدمات المعروضة";
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> LoadServiceListings()
        {
            // DataTables
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            // Filters
            var statusFilter = Request.Form["Status"].FirstOrDefault();

            var result = await _mediator.Send(new LoadServiceListingsQuery { });
            var query = result.Data;

            // Apply filters
            if (!string.IsNullOrEmpty(statusFilter) && Enum.TryParse<ServiceListingStatus>(statusFilter, out var parsedStatus))
                query = query.Where(p => p.Status == parsedStatus);

            // Search
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(p => p.Name.Contains(searchValue));
            }

            var recordsTotal = await query.CountAsync();

            var rows = await query
                     .OrderByDescending(p => p.CreatedAt)
                     .Skip(start)
                     .Take(length)
                     .Select(p => new
                     {
                         p.Id,
                         p.Name,
                         p.Description,
                         p.ImageURL,
                         p.Price,
                         p.CreatedAt,
                         p.Status,
                         p.ServiceProviderId,
                         ServiceProviderName = p.ServiceProvider != null ? p.ServiceProvider.DisplayName : null
                     })
                     .ToListAsync();

            var data = rows.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                description = p.Description,
                image = p.ImageURL,
                price = p.Price,
                createdAt = p.CreatedAt.Value.ToString("yyyy-MM-dd"),
                serviceProviderId = p.ServiceProviderId,
                serviceProvider = p.ServiceProviderName ?? "المتجر",
                statusValue = (int)p.Status,
                status = BuildStatusBadge(p.Status)
            }).ToList();

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            });
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var serviceProviders = await _mediator.Send(new GetAllServiceProvidersQuery { });
            ViewBag.ServiceProviders = serviceProviders.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceListingForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var serviceProviders = await _mediator.Send(new GetAllServiceProvidersQuery { });
                ViewBag.ServiceProviders = serviceProviders.Data;
                return View(dto);
            }

            // Admin-created service listings are the quality gate themselves: go live immediately
            var result = await _mediator.Send(new CreateServiceListingCommand { Dto = dto, InitialStatus = ServiceListingStatus.Published });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UploadImage(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadServiceListingImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadServiceListingImageCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction("Index");
        }

        [HttpPut("/Admin/ServiceListing/Edit/{serviceListingId}")]
        public async Task<IActionResult> Edit(int serviceListingId, [FromBody] ServiceListingForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var command = new UpdateServiceListingCommand { ServiceListingId = serviceListingId, Dto = dto };
            var result = await _mediator.Send(command);

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return Ok(new { id = serviceListingId, data = result.Data, message = "Updated Successfully" });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, ServiceListingStatus status)
        {
            var result = await _mediator.Send(new ChangeServiceListingStatusCommand { ServiceListingId = id, TargetStatus = status });

            if (result.Result.Code != ResultCodeStatus.Success)
                return Json(new { success = false, message = result.Result.Message });

            return Json(new { success = true, id = id, message = result.Result.Message });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteServiceListingCommand { ServiceListingId = id });

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
