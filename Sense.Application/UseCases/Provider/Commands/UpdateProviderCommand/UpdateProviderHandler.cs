using Sense.Application.Abstractions;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProviderDTOs;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Provider.Commands.UpdateProviderCommand
{
    public class UpdateProviderHandler : IRequestHandler<UpdateProviderCommand, ResponseResult<ProviderDto>>
    {
        private static readonly string[] AllowedLogoFormats = { "image/jpeg", "image/png", "image/jpg" };
        private const long MaxLogoFileSize = 5 * 1024 * 1024; // 5MB

        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IImageServices _imageServices;
        private readonly IMapper _mapper;
        public UpdateProviderHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IImageServices imageServices, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _imageServices = imageServices;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ProviderDto>> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.NotFound, "المستخدم غير موجود!!");

            var provider = await _repositoryManager.Provider.GetProviderByApplicationUserId(user.Id);
            if (provider is null)
                return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.NotFound, "المزود غير موجود!!");

            if (request.Dto.Logo is { Length: > 0 })
            {
                if (!AllowedLogoFormats.Contains(request.Dto.Logo.ContentType))
                    return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.Failed, "صيغة الصورة غير صالحة. الصيغ المسموح بها هي JPEG و PNG و JPG");

                if (request.Dto.Logo.Length > MaxLogoFileSize)
                    return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.Failed, "حجم الصورة يتجاوز الحد الأقصى المسموح به وهو 5 ميجابايت");

                var logoUrl = await _imageServices.UploadImageToFreeImageHost(request.Dto.Logo);
                if (string.IsNullOrEmpty(logoUrl))
                    return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.Failed, "فشل رفع الشعار");

                provider.LogoURL = logoUrl;
            }

            user.Email = request.Dto.Email;
            user.UserName = request.Dto.Email;
            user.PhoneNumber = request.Dto.PhoneNumber;

            var identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                var errors = string.Join(" | ", identityResult.Errors.Select(e => e.Description));
                return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.BadRequest, errors);
            }

            provider.DisplayName = request.Dto.DisplayName;
            provider.PhoneNumber = request.Dto.PhoneNumber;
            _repositoryManager.Provider.UpdateProvider(provider);
            await _repositoryManager.SaveAsync();

            var dto = _mapper.Map<ProviderDto>(provider);
            dto.Email = user.Email;
            return ResponseResult<ProviderDto>.GetResult(ResultCodeStatus.Success, dto, "تم تحديث بيانات المزود بنجاح");
        }
    }
}
