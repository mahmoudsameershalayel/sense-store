using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Infrastructure;
using Sense.Infrastructure.Extensions;
using Sense.Models.ProviderRegistration;
using Sense.Services;

namespace Sense.Controllers
{
    [AllowAnonymous]
    public class ProviderRegistrationController : Controller
    {
        private readonly SenseDbContext _context;
        private readonly IProviderRegistrationUploadService _uploads;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly ISmtpEmailService _emailService;
        private readonly ILogger<ProviderRegistrationController> _logger;

        public ProviderRegistrationController(
            SenseDbContext context,
            IProviderRegistrationUploadService uploads,
            UserManager<ApplicationUserTbl> userManager,
            ISmtpEmailService emailService,
            ILogger<ProviderRegistrationController> logger)
        {
            _context = context;
            _uploads = uploads;
            _userManager = userManager;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() => View(new ProviderRegistrationViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(11 * 1024 * 1024)]
        public async Task<IActionResult> Index(
            ProviderRegistrationViewModel model,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var email = model.Email.Trim();
            var normalizedEmail = email.ToUpperInvariant();
            var duplicateRequest = await _context.ProviderRequestTbls
                .AsNoTracking()
                .AnyAsync(
                    request => !request.IsDeleted
                        && request.Status == ProviderRequestStatus.Pending
                        && request.Email.ToUpper() == normalizedEmail,
                    cancellationToken);

            if (duplicateRequest)
            {
                ModelState.AddModelError(nameof(model.Email), "يوجد طلب قيد المراجعة لهذا البريد الإلكتروني.");
                return View(model);
            }

            var upload = await _uploads.SaveAsync(model.Document!, cancellationToken);
            if (!upload.Success || upload.File is null)
            {
                ModelState.AddModelError(nameof(model.Document), upload.Message);
                return View(model);
            }

            var request = new ProviderRequestTbl
            {
                FullName = model.FullName.Trim(),
                BusinessName = model.BusinessName.Trim(),
                Email = email,
                PhoneNumber = model.PhoneNumber.Trim(),
                BusinessDescription = model.BusinessDescription.Trim(),
                DocumentStoredName = upload.File.StoredName,
                DocumentOriginalName = upload.File.OriginalName,
                DocumentContentType = upload.File.ContentType,
                DocumentFileSize = upload.File.FileSize,
                AcceptedTerms = model.AcceptedTerms,
                Status = ProviderRequestStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            try
            {
                _context.ProviderRequestTbls.Add(request);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                await _uploads.DeleteAsync(upload.File);
                throw;
            }
            catch (Exception exception) when (exception is not OperationCanceledException)
            {
                _logger.LogError(exception, "Could not save provider request for {Email}.", email);
                await _uploads.DeleteAsync(upload.File);
                ModelState.AddModelError(string.Empty, "تعذر إرسال الطلب. يرجى المحاولة مرة أخرى.");
                return View(model);
            }

            await NotifyAdministratorsAsync(request);
            return RedirectToAction(nameof(Success));
        }

        [HttpGet]
        public IActionResult Success() => View();

        private async Task NotifyAdministratorsAsync(ProviderRequestTbl request)
        {
            try
            {
                var administrators = await _userManager.GetUsersInRoleAsync("Administrator");
                var detailsUrl = Url.Action(
                    "Details",
                    "ProviderRequests",
                    new { area = "Admin", id = request.Id },
                    Request.Scheme);

                var encodedBusinessName = WebUtility.HtmlEncode(request.BusinessName);
                var encodedApplicantName = WebUtility.HtmlEncode(request.FullName);
                var encodedDetailsUrl = WebUtility.HtmlEncode(detailsUrl ?? string.Empty);
                var body = $"""
                    <div style="font-family: Almarai, Arial, sans-serif; direction: rtl; text-align: right;">
                        <h2>طلب انضمام مزوّد جديد</h2>
                        <p>استلم Sense Store طلباً جديداً من <strong>{encodedBusinessName}</strong>، مقدم من {encodedApplicantName}.</p>
                        <p><a href="{encodedDetailsUrl}">فتح الطلب في لوحة التحكم</a></p>
                    </div>
                    """;

                foreach (var administrator in administrators.Where(user => !string.IsNullOrWhiteSpace(user.Email)))
                {
                    await _emailService.SendEmailAsync(
                        administrator.Email!,
                        "طلب انضمام مزوّد جديد - Sense Store",
                        body);
                }
            }
            catch (Exception exception)
            {
                _logger.LogWarning(exception, "Provider request {RequestId} was saved, but administrators were not notified.", request.Id);
            }
        }
    }
}
