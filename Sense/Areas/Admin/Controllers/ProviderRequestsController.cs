using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Infrastructure;
using Sense.Infrastructure.Extensions;
using Sense.Models.ProviderRegistration;

namespace Sense.Areas.Admin.Controllers
{
    public class ProviderRequestsController : AdminBaseController
    {
        private readonly SenseDbContext _context;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly ISmtpEmailService _emailService;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ProviderRequestsController> _logger;

        public ProviderRequestsController(
            SenseDbContext context,
            UserManager<ApplicationUserTbl> userManager,
            ISmtpEmailService emailService,
            IWebHostEnvironment environment,
            ILogger<ProviderRequestsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
            _environment = environment;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string status = "Pending",
            CancellationToken cancellationToken = default)
        {
            var query = _context.ProviderRequestTbls
                .AsNoTracking()
                .Where(request => !request.IsDeleted);

            if (Enum.TryParse<ProviderRequestStatus>(status, true, out var statusFilter))
            {
                query = query.Where(request => request.Status == statusFilter);
                ViewBag.SelectedStatus = statusFilter.ToString();
            }
            else
            {
                ViewBag.SelectedStatus = "All";
            }

            ViewBag.ActiveMenu = "ProviderRequests";
            ViewData["title"] = "طلبات انضمام المزودين";

            var requests = await query
                .OrderByDescending(request => request.CreatedAt)
                .ToListAsync(cancellationToken);

            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var request = await _context.ProviderRequestTbls
                .AsNoTracking()
                .Include(item => item.ApprovedProvider)
                .FirstOrDefaultAsync(item => item.Id == id && !item.IsDeleted, cancellationToken);

            if (request is null)
            {
                return NotFound();
            }

            ViewBag.ActiveMenu = "ProviderRequests";
            ViewData["title"] = "تفاصيل طلب المزود";
            return View(request);
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> Document(int id, CancellationToken cancellationToken)
        {
            var request = await _context.ProviderRequestTbls
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == id && !item.IsDeleted, cancellationToken);

            if (request is null || string.IsNullOrWhiteSpace(request.DocumentStoredName))
            {
                return NotFound();
            }

            var storedName = Path.GetFileName(request.DocumentStoredName);
            var fullPath = Path.Combine(
                _environment.ContentRootPath,
                "App_Data",
                "ProviderDocuments",
                storedName);

            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound();
            }

            var downloadName = Path.GetFileName(request.DocumentOriginalName);
            return PhysicalFile(
                fullPath,
                request.DocumentContentType,
                downloadName,
                enableRangeProcessing: true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(
            ProviderRequestReviewViewModel model,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = FirstModelError();
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }

            var temporaryPassword = GenerateTemporaryPassword();
            ProviderRequestTbl? request = null;

            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                request = await _context.ProviderRequestTbls
                    .FirstOrDefaultAsync(item => item.Id == model.Id && !item.IsDeleted, cancellationToken);

                if (request is null)
                {
                    return NotFound();
                }

                if (request.Status != ProviderRequestStatus.Pending)
                {
                    TempData["ErrorMessage"] = "تمت مراجعة هذا الطلب مسبقاً.";
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                }

                if (await _userManager.FindByEmailAsync(request.Email) is not null)
                {
                    TempData["ErrorMessage"] = "يوجد حساب مسجل بهذا البريد الإلكتروني بالفعل.";
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                }

                var user = new ApplicationUserTbl
                {
                    Email = request.Email,
                    UserName = request.Email,
                    EmailConfirmed = true,
                    FirstName = request.FullName,
                    LastName = string.Empty,
                    CompName = request.BusinessName,
                    PhoneNumber = request.PhoneNumber,
                    UserType = UserType.Provider,
                    IsActive = true
                };

                var createResult = await _userManager.CreateAsync(user, temporaryPassword);
                if (!createResult.Succeeded)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    TempData["ErrorMessage"] = JoinIdentityErrors(createResult);
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                }

                var roleResult = await _userManager.AddToRoleAsync(user, "Provider");
                if (!roleResult.Succeeded)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    TempData["ErrorMessage"] = JoinIdentityErrors(roleResult);
                    return RedirectToAction(nameof(Details), new { id = model.Id });
                }

                var provider = new ProviderTbl
                {
                    ApplicationUserId = user.Id,
                    DisplayName = request.BusinessName,
                    Description = request.BusinessDescription,
                    PhoneNumber = request.PhoneNumber,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };

                request.Status = ProviderRequestStatus.Approved;
                request.InternalNote = Clean(model.InternalNote);
                request.RejectionReason = null;
                request.ReviewedAt = DateTime.UtcNow;
                request.ReviewedByUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                request.ApprovedProvider = provider;
                request.ModifiedAt = DateTime.UtcNow;

                _context.ProviderTbls.Add(provider);
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                await transaction.RollbackAsync(CancellationToken.None);
                _logger.LogInformation(exception, "Provider request {RequestId} was reviewed concurrently.", model.Id);
                TempData["ErrorMessage"] = "قام مسؤول آخر بمراجعة هذا الطلب. تم تحديث الصفحة دون إنشاء حساب جديد.";
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch (Exception exception) when (exception is not OperationCanceledException)
            {
                await transaction.RollbackAsync(CancellationToken.None);
                _logger.LogError(exception, "Could not approve provider request {RequestId}.", model.Id);
                TempData["ErrorMessage"] = "تعذر قبول الطلب وإنشاء حساب المزود. لم يتم حفظ أي تغييرات.";
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }

            var loginUrl = Url.Action(
                "Login",
                "Account",
                new { area = string.Empty },
                Request.Scheme) ?? "/Account/Login";

            var emailSent = await _emailService.SendEmailAsync(
                request!.Email,
                "تم قبول طلب انضمامك كمزوّد - Sense Store",
                BuildApprovalEmail(request.BusinessName, request.Email, temporaryPassword, loginUrl));

            TempData[emailSent ? "Message" : "ErrorMessage"] = emailSent
                ? "تم قبول الطلب وإنشاء حساب المزود وإرسال بيانات الدخول."
                : "تم قبول الطلب وإنشاء الحساب، لكن تعذر إرسال بيانات الدخول. اطلب من المزود استخدام استعادة كلمة المرور.";

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(
            ProviderRequestReviewViewModel model,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(model.RejectionReason))
            {
                ModelState.AddModelError(nameof(model.RejectionReason), "سبب الرفض مطلوب.");
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = FirstModelError();
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }

            var request = await _context.ProviderRequestTbls
                .FirstOrDefaultAsync(item => item.Id == model.Id && !item.IsDeleted, cancellationToken);

            if (request is null)
            {
                return NotFound();
            }

            if (request.Status != ProviderRequestStatus.Pending)
            {
                TempData["ErrorMessage"] = "تمت مراجعة هذا الطلب مسبقاً.";
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }

            request.Status = ProviderRequestStatus.Rejected;
            request.InternalNote = Clean(model.InternalNote);
            request.RejectionReason = model.RejectionReason!.Trim();
            request.ReviewedAt = DateTime.UtcNow;
            request.ReviewedByUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.ModifiedAt = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                _logger.LogInformation(exception, "Provider request {RequestId} was reviewed concurrently.", model.Id);
                TempData["ErrorMessage"] = "قام مسؤول آخر بمراجعة هذا الطلب. تم تحديث الصفحة دون تغيير قراره.";
                return RedirectToAction(nameof(Details), new { id = model.Id });
            }

            var emailSent = await _emailService.SendEmailAsync(
                request.Email,
                "تحديث طلب الانضمام كمزوّد - Sense Store",
                BuildRejectionEmail(request.BusinessName, request.RejectionReason));

            TempData[emailSent ? "Message" : "ErrorMessage"] = emailSent
                ? "تم رفض الطلب وإبلاغ مقدم الطلب."
                : "تم رفض الطلب، لكن تعذر إرسال رسالة البريد الإلكتروني إلى مقدم الطلب.";

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        private string FirstModelError()
            => ModelState.Values
                .SelectMany(entry => entry.Errors)
                .Select(error => error.ErrorMessage)
                .FirstOrDefault(message => !string.IsNullOrWhiteSpace(message))
                ?? "البيانات المدخلة غير صالحة.";

        private static string JoinIdentityErrors(IdentityResult result)
            => string.Join(" | ", result.Errors.Select(error => error.Description));

        private static string? Clean(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

        private static string GenerateTemporaryPassword()
            => $"Tmp!{Convert.ToHexString(RandomNumberGenerator.GetBytes(8))}a7";

        private static string BuildApprovalEmail(
            string businessName,
            string email,
            string temporaryPassword,
            string loginUrl)
        {
            return $"""
                <div style="font-family: Almarai, Arial, sans-serif; direction: rtl; text-align: right;">
                    <h2>مرحباً {WebUtility.HtmlEncode(businessName)}</h2>
                    <p>تم قبول طلبك وإنشاء حساب المزوّد الخاص بك في Sense Store.</p>
                    <p><strong>البريد الإلكتروني:</strong> {WebUtility.HtmlEncode(email)}</p>
                    <p><strong>كلمة المرور المؤقتة:</strong> <code>{WebUtility.HtmlEncode(temporaryPassword)}</code></p>
                    <p><a href="{WebUtility.HtmlEncode(loginUrl)}">تسجيل الدخول إلى حسابك</a></p>
                    <p>يرجى تغيير كلمة المرور بعد أول تسجيل دخول.</p>
                </div>
                """;
        }

        private static string BuildRejectionEmail(string businessName, string rejectionReason)
        {
            return $"""
                <div style="font-family: Almarai, Arial, sans-serif; direction: rtl; text-align: right;">
                    <h2>تحديث طلب {WebUtility.HtmlEncode(businessName)}</h2>
                    <p>نأسف لعدم تمكننا من قبول طلب انضمامك كمزوّد في الوقت الحالي.</p>
                    <p><strong>السبب:</strong> {WebUtility.HtmlEncode(rejectionReason)}</p>
                </div>
                """;
        }
    }
}
