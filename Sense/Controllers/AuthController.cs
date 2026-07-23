using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Infrastructure.Extensions;
using Sense.Application.UseCases.Auth.Commands.LoginUserWebCommand;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace Sense.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<ApplicationUserTbl> _signInManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly ISmtpEmailService _emailService;
        private readonly IOtpService _otpService;
        private readonly IMediator _mediator;

        public AuthController(UserManager<ApplicationUserTbl> userManager, SignInManager<ApplicationUserTbl> signInManager, ISmtpEmailService emailService, IOtpService otpService, IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _otpService = otpService;
            _mediator = mediator;
        }

        // GET: Account/ForgotPassword
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST: Account/ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if user exists
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                TempData["Error"] = "لا يوجد حساب مسجل بهذا البريد الإلكتروني";
                return View(model);
            }

            // Generate OTP
            var otpCode = await _otpService.GenerateOtpAsync();

            // Store OTP
            await _otpService.StoreOtpAsync(model.Email, otpCode);

            // Send OTP via email
            var sent = await _emailService.SendOtpEmailAsync(model.Email, otpCode);

            if (!sent)
            {
                TempData["Error"] = "فشل إرسال رمز التحقق، يرجى المحاولة مرة أخرى";
                return View(model);
            }

            TempData["Success"] = "تم إرسال رمز التحقق إلى بريدك الإلكتروني";
            return RedirectToAction(nameof(VerifyOtp), new { email = model.Email });
        }

        // GET: Account/VerifyOtp
        [HttpGet]
        public IActionResult VerifyOtp(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction(nameof(ForgotPassword));
            }

            var model = new VerifyOtpDto { Email = email };
            return View(model);
        }

        // POST: Account/VerifyOtp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyOtp(VerifyOtpDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var validate = await _otpService.ValidateOtpAsync(model.Email, model.OtpCode);
            // Validate OTP
            if (!validate)
            {
                TempData["Error"] = "رمز التحقق غير صحيح أو منتهي الصلاحية";
                return View(model);
            }

            // OTP is valid, redirect to reset password
            return RedirectToAction(nameof(ResetPassword), new
            {
                email = model.Email,
                otpCode = model.OtpCode
            });
        }

        // GET: Account/ResetPassword
        [HttpGet]
        public async Task<IActionResult> ResetPassword(string email, string otpCode)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(otpCode))
            {
                return RedirectToAction(nameof(ForgotPassword));
            }

            // Verify OTP is still valid
            var validate = await _otpService.ValidateOtpAsync(email, otpCode);
            if (!validate)
            {
                TempData["Error"] = "انتهت صلاحية رمز التحقق، يرجى طلب رمز جديد";
                return RedirectToAction(nameof(ForgotPassword));
            }

            var model = new ResetPasswordDto
            {
                Email = email,
                OtpCode = otpCode
            };
            return View(model);
        }

        // POST: Account/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Final OTP validation
            var validate = await _otpService.ValidateOtpAsync(model.Email, model.OtpCode);
            if (!validate)
            {
                TempData["Error"] = "رمز التحقق غير صحيح أو منتهي الصلاحية";
                return RedirectToAction(nameof(ForgotPassword));
            }

            // Find user
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                TempData["Error"] = "حدث خطأ، يرجى المحاولة مرة أخرى";
                return RedirectToAction(nameof(ForgotPassword));
            }

            // Reset password
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

            if (result.Succeeded)
            {
                // Remove OTP from storage
                await _otpService.RemoveOtpAsync(model.Email);

                TempData["Success"] = "تم تغيير كلمة المرور بنجاح";
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        // POST: Account/ResendOtp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResendOtp(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, message = "البريد الإلكتروني مطلوب" });
            }

            // Check if user exists
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return Json(new { success = false, message = "لا يوجد حساب مسجل بهذا البريد الإلكتروني" });
            }

            // Generate new OTP
            var otpCode = await _otpService.GenerateOtpAsync();

            // Store OTP
            await _otpService.StoreOtpAsync(email, otpCode);

            // Send OTP via email
            var sent = await _emailService.SendOtpEmailAsync(email, otpCode);

            if (!sent)
            {
                return Json(new { success = false, message = "فشل إرسال رمز التحقق" });
            }

            return Json(new { success = true, message = "تم إرسال رمز التحقق الجديد" });
        }

        [HttpGet]
        [Route("/Login")]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(UserForLoginDto user, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View();

            var command = new LoginUserWebCommand { Dto = user };
            var result = await _mediator.Send(command);
            if (result.Result.Code == ResultCodeStatus.Forbiden)
            {
                return RedirectToAction("VerifyEmail", "Account", new { email = user.Email });
            }
            if (result.Result.Code == ResultCodeStatus.BadRequest)
            {
                ViewBag.Message = result.Result.Message;
                ModelState.AddModelError(string.Empty, "Invalid login attempt.2");
                return View();
            }
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return LocalRedirect(returnUrl);

            /* string token = await GetApiTokenAsync(user.UserName, user.Password); // Get from secure source
             HttpContext.Session.SetString("JwtToken", token);

                                 */
            if (result.Data.UserType == "Administrator")
            {
                return LocalRedirect("/admin/home");

            }
            else if (result.Data.UserType == "Supervisor")
            {
                return LocalRedirect("/supervisor/home");
            }
            else
            {
                return LocalRedirect("/techSupport/home");
            }

        }
        [HttpGet("/Denied")]
        public IActionResult Denied()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<string> GetApiTokenAsync(string username, string password)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                username = username,
                password = password
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://qrgaza-001-site1.anytempurl.com/SenseAPI/Auth/Authenticate", content);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(responseContent);
            return result.token; // adjust based on your API's response format
        }

    }
}
