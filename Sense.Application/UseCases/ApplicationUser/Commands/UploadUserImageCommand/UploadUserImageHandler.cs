using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Product.Commands.UploadProductImageCommand;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Commands.UploadUserImageCommand
{
    public class UploadUserImageHandler : IRequestHandler<UploadUserImageCommand, ResponseResult<string>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IImageServices _imageServices;

        public UploadUserImageHandler(UserManager<ApplicationUserTbl> userManager, IImageServices imageServices)
        {
            _userManager = userManager;
            _imageServices = imageServices;
        }

        public async Task<ResponseResult<string>> Handle(UploadUserImageCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Dto.Id);
            if (user is null)
                return ResponseResult<string>.GetResult(ResultCodeStatus.NotFound, $"User with id : {request.Dto.Id} not found");

            if (request.Dto.Image == null || request.Dto.Image.Length == 0)
            {
                return ResponseResult<string>.GetResult(ResultCodeStatus.Failed, "No image provided");
            }

            var allowedFormats = new[] { "image/jpeg", "image/png", "image/jpg" };
            if (!allowedFormats.Contains(request.Dto.Image.ContentType))
            {
                return ResponseResult<string>.GetResult(ResultCodeStatus.Failed, "Invalid image format. Allowed formats are JPEG, PNG, and GIF.");
            }

            // Validate file size (e.g., max 5MB)
            const long maxFileSize = 5 * 1024 * 1024; // 5MB
            if (request.Dto.Image.Length > maxFileSize)
            {
                return ResponseResult<string>.GetResult(ResultCodeStatus.Failed, "Image size exceeds the maximum allowed size of 5MB.");
            }

            // Instead of saving the image to local storage, upload to FreeImage.Host
            var imageUrl = await _imageServices.UploadImageToFreeImageHost(request.Dto.Image);

            if (string.IsNullOrEmpty(imageUrl))
            {
                return ResponseResult<string>.GetResult(ResultCodeStatus.Failed, "Failed to upload image to FreeImage.Host.");
            }

            // Store the URL returned from FreeImage.Host
            user.ImageURL = imageUrl;
            await _userManager.UpdateAsync(user);

            return ResponseResult<string>.GetResult(ResultCodeStatus.Success, imageUrl, "The image uploaded successfully");
        }



    }
}
