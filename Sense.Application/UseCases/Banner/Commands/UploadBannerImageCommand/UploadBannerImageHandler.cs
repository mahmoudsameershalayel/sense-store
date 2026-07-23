using Sense.Application.DomainEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Product.Commands.UploadProductImageCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Banner.Commands.UploadBannerImageCommand
{
	public class UploadBannerImageHandler : IRequestHandler<UploadBannerImageCommand, ResponseResult<string>>
	{
		private readonly IRepositoryManager _repositoryManager;
        private readonly IImageServices _imageServices;
		public UploadBannerImageHandler(IRepositoryManager repositoryManager, IImageServices imageServices)
		{
			_repositoryManager = repositoryManager;
            _imageServices = imageServices;
		}

		public async Task<ResponseResult<string>> Handle(UploadBannerImageCommand request, CancellationToken cancellationToken)
		{
			var item = await _repositoryManager.Banner.GetHomeBannerByIdAsync(request.Dto.Id);
			if (item is null)
			{
				return ResponseResult<string>.GetResult(ResultCodeStatus.NotFound, $"Banner with id : {request.Dto.Id} not found");
			}
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

            var imageUrl = await _imageServices.UploadImageToFreeImageHost(request.Dto.Image);
            if (string.IsNullOrEmpty(imageUrl))
            {
                return ResponseResult<string>.GetResult(ResultCodeStatus.Failed, "Failed to upload image to FreeImage.Host.");
            }
			
			item.ImageURL = imageUrl;
			_repositoryManager.Banner.UpdateHomeBanner(item);
			await _repositoryManager.SaveAsync();

            return ResponseResult<string>.GetResult(ResultCodeStatus.Success, imageUrl, $"The image uploaded successfully");
		}
	}
}
