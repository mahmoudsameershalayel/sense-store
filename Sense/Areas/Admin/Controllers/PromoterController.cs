using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sense.Areas.Admin.Models;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace Sense.Areas.Admin.Controllers
{
    public class PromoterController : AdminBaseController
    {
        private const string PromoterRole = "Promoter";

        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMediator _mediator;

        public PromoterController(
            UserManager<ApplicationUserTbl> userManager,
            RoleManager<IdentityRole> roleManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.ActiveMenu = "Promoters";
            ViewData["title"] = "إدارة المروجين";

            var promoters = await _userManager.Users
                .Where(u => u.UserType == UserType.Promoter)
                .OrderBy(u => u.Email)
                .ToListAsync();

            ViewBag.Promoters = promoters;
            return View(new PromoterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PromoterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .Distinct()
                    .ToList();

                return Json(new { success = false, message = validationErrors.FirstOrDefault() ?? "الرجاء التحقق من صحة البيانات." });
            }

            var fullName = model.FullName.Trim();
            var phoneNumber = model.PhoneNumber.Trim();
            var internationalPhone = BuildInternationalPhone(model.CountryCode, phoneNumber);
            var email = BuildPromoterEmail(internationalPhone);

            if (await _userManager.FindByEmailAsync(email) is not null)
            {
                return Json(new { success = false, message = "يوجد حساب مروج مسجل بهذا الرقم بالفعل." });
            }

            var password = GeneratePassword();

            var user = new ApplicationUserTbl
            {
                Email = email,
                UserName = email,
                EmailConfirmed = true,
                FirstName = fullName,
                LastName = string.Empty,
                PhoneNumber = internationalPhone,
                Phone1 = $"+{internationalPhone}",
                UserType = UserType.Promoter,
                IsActive = true
            };

            var createResult = await _userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
            {
                return Json(new { success = false, message = string.Join(" | ", createResult.Errors.Select(e => e.Description)) });
            }

            await EnsurePromoterRoleAsync();

            var roleResult = await _userManager.AddToRoleAsync(user, PromoterRole);
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return Json(new { success = false, message = "تعذر إسناد دور المروج للحساب." });
            }

            var loginUrl = $"{Request.Scheme}://{Request.Host}/Account/Login";
            var storeName = await GetStoreNameAsync();
            var message = BuildWhatsAppMessage(fullName, storeName, email, password, loginUrl);
            var whatsAppUrl = $"https://wa.me/{internationalPhone}?text={Uri.EscapeDataString(message)}";

            return Json(new
            {
                success = true,
                message = "تم إنشاء حساب المروج بنجاح.",
                whatsappUrl = whatsAppUrl,
                email = email,
                password = password
            });
        }

        private async Task<string> GetStoreNameAsync()
        {
            try
            {
                var result = await _mediator.Send(new GetCenterSettingQuery());
                var name = result.Data?.CenterName;
                return string.IsNullOrWhiteSpace(name) ? "متجرنا" : name.Trim();
            }
            catch
            {
                return "متجرنا";
            }
        }

        private async Task EnsurePromoterRoleAsync()
        {
            if (!await _roleManager.RoleExistsAsync(PromoterRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(PromoterRole));
            }
        }

        private static string BuildPromoterEmail(string internationalPhone)
        {
            return $"promo{internationalPhone}@wesense.com";
        }

        private static string BuildInternationalPhone(string countryCode, string localPhone)
        {
            var local = localPhone.Trim();

            if (local.StartsWith("0"))
                local = local.Substring(1);

            return $"{countryCode}{local}";
        }

        private static string GeneratePassword()
        {
            const string chars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var randomBytes = new byte[10];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            var result = new StringBuilder(10);
            foreach (var b in randomBytes)
            {
                result.Append(chars[b % chars.Length]);
            }

            return result.ToString();
        }

        private static string BuildWhatsAppMessage(string fullName, string storeName, string email, string password, string loginUrl)
        {
            var message = new StringBuilder();
            message.AppendLine($"مرحباً {fullName} 🌟");
            message.AppendLine();
            message.AppendLine($"تم إنشاء حسابك كمروج في {storeName} بنجاح 🎉");
            message.AppendLine();
            message.AppendLine("بيانات تسجيل الدخول:");
            message.AppendLine($"📧 البريد الإلكتروني: {email}");
            message.AppendLine($"🔑 كلمة المرور: {password}");
            message.AppendLine();
            message.AppendLine($"🔗 رابط تسجيل الدخول:");
            message.AppendLine(loginUrl);
            message.AppendLine();
            message.Append("شكراً لانضمامك لفريق المروجين لدينا! 🌹");

            return message.ToString();
        }
    }
}
