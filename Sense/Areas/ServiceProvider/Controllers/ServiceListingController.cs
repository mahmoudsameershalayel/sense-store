using Sense.Domain.Enums;
using Sense.Application.DTOs.ServiceListingDTOs;
using Sense.Application.UseCases.ServiceListing.Commands.ChangeServiceListingStatusCommand;
using Sense.Application.UseCases.ServiceListing.Commands.CreateServiceListingCommand;
using Sense.Application.UseCases.ServiceListing.Commands.UpdateServiceListingCommand;
using Sense.Application.UseCases.ServiceListing.Commands.UploadServiceListingImageCommand;
using Sense.Application.UseCases.ServiceListing.Queries.GetServiceListingByIdQuery;
using Sense.Application.UseCases.ServiceListing.Queries.LoadServiceListingsQuery;
using Sense.Application.UseCases.ServiceProvider.Queries.GetServiceProviderByUserIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Sense.Areas.ServiceProvider.Controllers
{
    public class ServiceListingController : ServiceProviderBaseController
    {
        private readonly IMediator _mediator;
        public ServiceListingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private async Task<Sense.Application.DTOs.ServiceProviderDTOs.ServiceProviderDto?> GetCurrentServiceProvider()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new GetServiceProviderByUserIdQuery { CurrentUserId = userId });
            return result.Data;
        }

        public async Task<IActionResult> Index()
        {
            var provider = await GetCurrentServiceProvider();
            if (provider is null)
                return Forbid();

            var result = await _mediator.Send(new LoadServiceListingsQuery { ServiceProviderId = provider.Id });
            var serviceListings = await result.Data.OrderByDescending(p => p.CreatedAt).ToListAsync();

            ViewBag.ServiceProviderName = provider.DisplayName;
            ViewData["title"] = "خدماتي";
            return View(serviceListings);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceListingForCreateUpdateDto dto)
        {
            var provider = await GetCurrentServiceProvider();
            if (provider is null)
                return Forbid();

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            // Keep the service listing private until its required image is uploaded.
            dto.ServiceProviderId = provider.Id;
            var result = await _mediator.Send(new CreateServiceListingCommand { Dto = dto, InitialStatus = ServiceListingStatus.Draft });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = "تم حفظ بيانات الخدمة. ارفع صورتها لإكمال النشر مباشرة.";
            return RedirectToAction(nameof(UploadImage), new { id = result.Data.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var provider = await GetCurrentServiceProvider();
            if (provider is null)
                return Forbid();

            var result = await _mediator.Send(new GetServiceListingByIdQuery { ServiceListingId = id });
            var serviceListing = result.Data;

            if (serviceListing is null || serviceListing.ServiceProviderId != provider.Id)
                return NotFound();

            if (serviceListing.Status == ServiceListingStatus.Archived)
            {
                TempData["ErrorMessage"] = "لا يمكن تعديل خدمة مؤرشفة.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ServiceListingId = id;

            var dto = new ServiceListingForCreateUpdateDto
            {
                Name = serviceListing.Name,
                Description = serviceListing.Description,
                Price = serviceListing.Price,
                ServiceProviderId = serviceListing.ServiceProviderId
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ServiceListingForCreateUpdateDto dto)
        {
            var provider = await GetCurrentServiceProvider();
            if (provider is null)
                return Forbid();

            var existing = await _mediator.Send(new GetServiceListingByIdQuery { ServiceListingId = id });
            var serviceListing = existing.Data;

            if (serviceListing is null || serviceListing.ServiceProviderId != provider.Id)
                return NotFound();

            if (serviceListing.Status == ServiceListingStatus.Archived)
            {
                TempData["ErrorMessage"] = "لا يمكن تعديل خدمة مؤرشفة.";
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                ViewBag.ServiceListingId = id;
                return View(dto);
            }

            dto.ServiceProviderId = provider.Id;
            var result = await _mediator.Send(new UpdateServiceListingCommand { ServiceListingId = id, Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Success)
                TempData["ErrorMessage"] = result.Result.Message;
            else
                TempData["Message"] = "تم تحديث الخدمة بنجاح.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UploadImage(int id)
        {
            var provider = await GetCurrentServiceProvider();
            if (provider is null)
                return Forbid();

            var result = await _mediator.Send(new GetServiceListingByIdQuery { ServiceListingId = id });
            if (result.Data is null || result.Data.ServiceProviderId != provider.Id)
                return NotFound();

            if (result.Data.Status == ServiceListingStatus.Archived)
            {
                TempData["ErrorMessage"] = "لا يمكن نشر خدمة مؤرشفة.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadServiceListingImageDto dto)
        {
            var provider = await GetCurrentServiceProvider();
            if (provider is null)
                return Forbid();

            var existing = await _mediator.Send(new GetServiceListingByIdQuery { ServiceListingId = dto.Id });
            if (existing.Data is null || existing.Data.ServiceProviderId != provider.Id)
                return NotFound();

            if (existing.Data.Status == ServiceListingStatus.Archived)
            {
                TempData["ErrorMessage"] = "لا يمكن نشر خدمة مؤرشفة.";
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Id = dto.Id;
                return View();
            }

            var result = await _mediator.Send(new UploadServiceListingImageCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }

            if (existing.Data.Status != ServiceListingStatus.Published)
            {
                var publishResult = await _mediator.Send(new ChangeServiceListingStatusCommand
                {
                    ServiceListingId = dto.Id,
                    TargetStatus = ServiceListingStatus.Published,
                    ActingServiceProviderId = provider.Id
                });

                if (publishResult.Result.Code != ResultCodeStatus.Success)
                {
                    TempData["ErrorMessage"] = publishResult.Result.Message;
                    return RedirectToAction(nameof(Index));
                }
            }

            TempData["Message"] = "تم رفع الصورة ونشر الخدمة مباشرة في المتجر.";
            return RedirectToAction(nameof(Index));
        }
    }
}
