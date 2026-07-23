using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.UseCases.Address.Queries.GetAllAddressesQuery;
using Sense.Application.UseCases.Address.Queries.GetMyAllAddressesQuery;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UploadUserImageCommand;
using Sense.Application.UseCases.ApplicationUser.Queries.GetUserByIdQuery;
using Sense.Application.UseCases.ApplicationUser.Queries.IsCustomerQuery;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsQuery;
using Sense.Application.UseCases.Auth.Commands.LoginUserWebCommand;
using Sense.Application.UseCases.Auth.Commands.RegisterUserCommand;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.ChatMessage.Queries.GetAllUserChatMessageQuery;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetAllFreeMaintenanceOfferQuery;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetOfferEligibilityByCustomerIdQuery;
using Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllMaintenanceRecordByCustomerIdQuery;
using Sense.Application.UseCases.Order.Queries.GetAllOrdersQuery;
using Sense.Application.UseCases.Service.Queries.GetAllServicesQuery;
using Sense.Application.UseCases.Wallet.Queries.GetWalletByCustomerIdQuery;
using Sense.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Sense.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUserTbl> _signInManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IOtpService _otpService;
        private readonly ISmtpEmailService _emailService;
        private readonly IMediator _mediator;

        public AccountController(SignInManager<ApplicationUserTbl> signInManager, UserManager<ApplicationUserTbl> userManager, IOtpService otpService, ISmtpEmailService emailService, IMediator mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _otpService = otpService;
            _emailService = emailService;
            _mediator = mediator;
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index(AppointmentParameters? appointmentParameters , MaintenanceRecordParameters? maintenanceRecordParameters)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var allAppointments = await _mediator.Send(new GetAllAppointmentsQuery { AppointmentParameters = null , CurrentUserId = userId });
            var appointments = await _mediator.Send(new GetAllAppointmentsQuery { AppointmentParameters = appointmentParameters , CurrentUserId = userId });
            var addresses = await _mediator.Send(new GetMyAllAddressesQuery {CurrentUserId = userId });
            var services = await _mediator.Send(new GetAllServicesQuery { });
            var maintenanceRecords = await _mediator.Send(new GetAllMaintenanceRecordByCustomerIdQuery {CurrentUserId = userId  , MaintenanceRecordParameters = maintenanceRecordParameters});
            var brands = await _mediator.Send(new GetAllBrandsQuery { });
            var orders = await _mediator.Send(new GetAllOrdersQuery {CurrentUserId = userId , OrderParameters = new OrderParameters { } });
            var freeMaintenanceOffers = await _mediator.Send(new GetAllFreeMaintenanceOfferQuery { });
            var activeFreeMaintenanceOffers = freeMaintenanceOffers?.Data?.Where(x => x.IsActive ==true).ToList();
            var wallet = await _mediator.Send(new GetWalletByCustomerIdQuery {CurrentUserId = userId });
            var userMessages = await _mediator.Send(new GetAllUserChatMessageQuery {UserId = userId });
            var allMaintenance = await _mediator.Send(new GetAllMaintenanceRecordByCustomerIdQuery {MaintenanceRecordParameters = new MaintenanceRecordParameters(), CurrentUserId = userId });
            var completedMaintenance = allMaintenance.Data.Where(x => x.Status == "Completed").ToList();
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = userId });
            var customer = await _mediator.Send(new GetCustomerQuery { UserId = userId });
           
            
            // Pass the paged data and pagination info to the view
            ViewBag.Appointments = appointments.Data;
            ViewBag.Orders = orders.Data;
            ViewBag.Addresses = addresses.Data;
            ViewBag.MaintenanceRecords = maintenanceRecords.Data;
            ViewBag.FreeMaintenanceOffers = activeFreeMaintenanceOffers;
            ViewBag.Brands = brands.Data;
            ViewBag.User = user.Data;
            ViewBag.Wallet = wallet.Data;
            ViewBag.Services = services.Data;
            ViewBag.UserMessages = userMessages.Data;
            ViewBag.Customer = customer;

            ViewBag.AppointmentTotalPages = appointments.Data.MetaData.TotalPages;
            ViewBag.AppointmentCurrentPage = appointments.Data.MetaData.CurrentPage;

            ViewBag.MaintenanceTotalPages = maintenanceRecords.Data.MetaData.TotalPages;
            ViewBag.MaintenanceCurrentPage = maintenanceRecords.Data.MetaData.CurrentPage;


            ViewBag.Token = HttpContext.Session.GetString("JwtToken");

            return View();
        }

        [HttpGet]
        public IActionResult IsAuthenticated()
        {
            return Json(new { isAuthenticated = User.Identity.IsAuthenticated });
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _mediator.Send(new GetUserByIdQuery { UserId = userId });
            return View(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] ApplicationUserForUpdateDto dto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                
                var user = await _mediator.Send(new UpdateUserCommand { UserId = userId, Dto = dto });

                if (user.Data != null)
                {
                    return Ok(user.Data);
                }
                else
                {
                    return BadRequest("Failed to update profile.");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(IFormFile image)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uploadUserImageDto = new UploadUserImageDto { Id = userId  , Image = image};
            var result = await _mediator.Send(new UploadUserImageCommand { Dto = uploadUserImageDto });
            if (result.Result.Code == ResultCodeStatus.BadRequest)
                return Json(new { success = false, message = result.Result.Message });

            return Json(new { success = true, result = result.Data });

        }



        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto dto, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(dto);

            var command = new LoginUserWebCommand { Dto = dto };
            var result = await _mediator.Send(command);

            if (result.Result.Code == ResultCodeStatus.Forbiden)
            {
                return RedirectToAction(nameof(VerifyEmail), new { email = dto.Email });
            }

            if (result.Result.Code == ResultCodeStatus.BadRequest)
            {
                TempData["Message"] = "error in username or password!!";
                ModelState.AddModelError(string.Empty, "البريد الإلكتروني أو كلمة المرور غير صحيحة!!");
                return View();
            }
           /* string token = await GetApiTokenAsync(dto.UserName, dto.Password); // Get from secure source
            HttpContext.Session.SetString("JwtToken", token);  */
            var loggedInUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (loggedInUser?.UserType == UserType.Provider)
            {
                return LocalRedirect("/Provider/Product/Index");
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            return LocalRedirect("/Account/Index");
        }

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto dto, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(dto);

            var command = new RegisterUserCommand { Dto = dto };
            var result = await _mediator.Send(command);
            if (result.Result.Code == ResultCodeStatus.BadRequest)
            {
                ViewBag.Message = result.Result.Message;
                ModelState.AddModelError(string.Empty, "محاولة تسجيل فاشلة!");
                return View();
            }

            var otpCode = await _otpService.GenerateOtpAsync();
            await _otpService.StoreOtpAsync(dto.Email, otpCode);
            await _emailService.SendOtpEmailAsync(dto.Email, otpCode);

            return RedirectToAction(nameof(VerifyEmail), new { email = dto.Email, returnUrl });
        }

        [HttpGet]
        public IActionResult VerifyEmail(string email, string? returnUrl = null)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction(nameof(Register));
            }

            ViewData["ReturnUrl"] = returnUrl;
            var model = new VerifyOtpDto { Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyEmail(VerifyOtpDto model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var validate = await _otpService.ValidateOtpAsync(model.Email, model.OtpCode);
            if (!validate)
            {
                TempData["Error"] = "رمز التحقق غير صحيح أو منتهي الصلاحية";
                return View(model);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                TempData["Error"] = "حدث خطأ، يرجى المحاولة مرة أخرى";
                return View(model);
            }

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            await _signInManager.SignInAsync(user, isPersistent: false);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            return LocalRedirect("/Account/Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResendVerificationOtp(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, message = "البريد الإلكتروني مطلوب" });
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return Json(new { success = false, message = "لا يوجد حساب مسجل بهذا البريد الإلكتروني" });
            }

            var otpCode = await _otpService.GenerateOtpAsync();
            await _otpService.StoreOtpAsync(email, otpCode);
            var sent = await _emailService.SendOtpEmailAsync(email, otpCode);

            if (!sent)
            {
                return Json(new { success = false, message = "فشل إرسال رمز التحقق" });
            }

            return Json(new { success = true, message = "تم إرسال رمز التحقق الجديد" });
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
            if (result.Data == null)
                return null;
            return result.data.accessToken; // adjust based on your API's response format
        }


    }
}
