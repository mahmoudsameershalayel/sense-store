using Sense.Application.Abstractions;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceProviderDTOs;
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

namespace Sense.Application.UseCases.ServiceProvider.Commands.UpdateServiceProviderCommand
{
    public class UpdateServiceProviderHandler : IRequestHandler<UpdateServiceProviderCommand, ResponseResult<ServiceProviderDto>>
    {
        private static readonly string[] AllowedLogoFormats = { "image/jpeg", "image/png", "image/jpg" };
        private const long MaxLogoFileSize = 5 * 1024 * 1024; // 5MB

        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IImageServices _imageServices;
        private readonly IMapper _mapper;
        public UpdateServiceProviderHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IImageServices imageServices, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _imageServices = imageServices;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceProviderDto>> Handle(UpdateServiceProviderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.NotFound, "المستخدم غير موجود!!");

            var serviceProvider = await _repositoryManager.ServiceProvider.GetServiceProviderByApplicationUserId(user.Id);
            if (serviceProvider is null)
                return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.NotFound, "مزود الخدمة غير موجود!!");

            if (request.Dto.Logo is { Length: > 0 })
            {
                if (!AllowedLogoFormats.Contains(request.Dto.Logo.ContentType))
                    return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.Failed, "صيغة الصورة غير صالحة. الصيغ المسموح بها هي JPEG و PNG و JPG");

                if (request.Dto.Logo.Length > MaxLogoFileSize)
                    return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.Failed, "حجم الصورة يتجاوز الحد الأقصى المسموح به وهو 5 ميجابايت");

                var logoUrl = await _imageServices.UploadImageToFreeImageHost(request.Dto.Logo);
                if (string.IsNullOrEmpty(logoUrl))
                    return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.Failed, "فشل رفع الشعار");

                serviceProvider.LogoURL = logoUrl;
            }

            user.Email = request.Dto.Email;
            user.UserName = request.Dto.Email;
            user.PhoneNumber = request.Dto.PhoneNumber;

            var identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                var errors = string.Join(" | ", identityResult.Errors.Select(e => e.Description));
                return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.BadRequest, errors);
            }

            serviceProvider.DisplayName = request.Dto.DisplayName;
            serviceProvider.PhoneNumber = request.Dto.PhoneNumber;
            _repositoryManager.ServiceProvider.UpdateServiceProvider(serviceProvider);
            await _repositoryManager.SaveAsync();

            var dto = _mapper.Map<ServiceProviderDto>(serviceProvider);
            dto.Email = user.Email;
            return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.Success, dto, "تم تحديث بيانات مزود الخدمة بنجاح");
        }
    }
}
