using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.ServiceProviderDTOs;
using Sense.Application.UseCases.ApplicationUser.Commands.CreateUserCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserAccountStatusCommand;
using Sense.Application.UseCases.ApplicationUser.Commands.UploadUserImageCommand;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllUsersQuery;
using Sense.Application.UseCases.ServiceProvider.Commands.DeleteServiceProviderCommand;
using Sense.Application.UseCases.ServiceProvider.Commands.UpdateServiceProviderCommand;
using Sense.Application.UseCases.ServiceProvider.Queries.GetServiceProviderByUserIdQuery;
using Sense.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Sense.Areas.Admin.Controllers
{
    public class ServiceProviderController : AdminBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISmtpEmailService _emailService;
        public ServiceProviderController(IMediator mediator, ISmtpEmailService emailService)
        {
            _mediator = mediator;
            _emailService = emailService;
        }
        public async Task<IActionResult> Index(UserParameters? userParameters)
        {
            var result = await _mediator.Send(new GetAllUsersQuery { UserType = UserType.ServiceProvider, UserParameters = userParameters });
            var items = result.Data;

            ViewBag.CurrentPage = userParameters.PageNumber;
            ViewBag.PageSize = userParameters.PageSize;
            ViewBag.SearchTerm = userParameters.Name;
            ViewBag.TotalPages = result.Data.MetaData.TotalPages;

            ViewBag.ActiveMenu = "ServiceProviders";
            ViewData["title"] = "مزودو الخدمات";
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(string providerName, UserForRegisterDto dto)
        {
            ModelState.Remove(nameof(dto.Password));
            ModelState.Remove(nameof(dto.FirstName));
            ModelState.Remove(nameof(dto.LastName));

            if (!ModelState.IsValid)
                return View(dto);

            var tempPassword = GenerateTempPassword();
            dto.Password = tempPassword;
            dto.FirstName = providerName;
            dto.LastName = string.Empty;

            var result = await _mediator.Send(new CreateUserCommand { UserType = UserType.ServiceProvider, ProviderName = providerName, Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }

            await _emailService.SendEmailAsync(dto.Email!, "تم إنشاء حسابك كمزود خدمة في Sense Store", BuildWelcomeEmailBody(providerName, tempPassword));

            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        private static string GenerateTempPassword()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789";
            var bytes = RandomNumberGenerator.GetBytes(10);
            var result = new char[10];
            for (int i = 0; i < result.Length; i++)
                result[i] = chars[bytes[i] % chars.Length];
            return new string(result);
        }

        private static string BuildWelcomeEmailBody(string providerName, string tempPassword)
        {
            return $@"
                <div style=""font-family: Almarai, Arial, sans-serif; direction: rtl; text-align: right;"">
                    <h2 style=""color:#253F8E;"">مرحباً {providerName}</h2>
                    <p>تم إنشاء حسابك كمزود خدمة في Sense Store. يمكنك تسجيل الدخول باستخدام كلمة المرور المؤقتة التالية:</p>
                    <p style=""font-size: 24px; font-weight: bold; letter-spacing: 2px; color:#061C42;"">{tempPassword}</p>
                    <p style=""color:#888; font-size: 13px;"">لأسباب أمنية، يرجى تغيير كلمة المرور فور تسجيل الدخول.</p>
                </div>";
        }

        [HttpGet]
        public IActionResult UploadImage(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadUserImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadUserImageCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            var result = await _mediator.Send(new UpdateUserAccountStatusCommand { UserId = id });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return Json(new { success = false, message = result.Result.Message });
            }

            TempData["Message"] = result.Result.Message;
            return Json(new { success = true, id = id, message = result.Result.Message });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var result = await _mediator.Send(new GetServiceProviderByUserIdQuery { CurrentUserId = id });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }

            ViewBag.UserId = id;
            var dto = new ServiceProviderForUpdateDto
            {
                DisplayName = result.Data.DisplayName,
                Email = result.Data.Email,
                PhoneNumber = result.Data.PhoneNumber,
                LogoURL = result.Data.LogoURL
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ServiceProviderForUpdateDto dto)
        {
            ViewBag.UserId = id;
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _mediator.Send(new UpdateServiceProviderCommand { UserId = id, Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                ModelState.AddModelError(string.Empty, result.Result.Message);
                return View(dto);
            }

            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _mediator.Send(new DeleteServiceProviderCommand { UserId = id });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                return Json(new { success = false, message = result.Result.Message });
            }

            return Json(new { success = true, id = id, message = result.Result.Message });
        }

    }
}
