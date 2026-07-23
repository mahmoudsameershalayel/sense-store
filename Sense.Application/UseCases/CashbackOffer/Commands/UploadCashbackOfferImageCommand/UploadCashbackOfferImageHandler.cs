using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Cateogry.Commands.UploadCategoryImageCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Commands.UploadCashbackOfferImageCommand
{
    public class UploadCashbackOfferImageHandler : IRequestHandler<UploadCashbackOfferImageCommand, ResponseResult<string>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IImageServices _imageServices;
        public UploadCashbackOfferImageHandler(IRepositoryManager repositoryManager, IImageServices imageServices)
        {
            _repositoryManager = repositoryManager;
            _imageServices = imageServices;
        }

        public async Task<ResponseResult<string>> Handle(UploadCashbackOfferImageCommand request, CancellationToken cancellationToken)
        {
            var cashBackOffer = await _repositoryManager.CashbackOffer.GetOfferByIdAsync(request.Dto.Id);
            if (cashBackOffer is null)
                return ResponseResult<string>.GetResult(ResultCodeStatus.NotFound, $"Category with id : {request.Dto.Id} not found");
            
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
            cashBackOffer.ImageURL = imageUrl;
            await _repositoryManager.SaveAsync();
            return ResponseResult<string>.GetResult(ResultCodeStatus.Success, imageUrl, $"The image uploaded successfully");
        }
    }
}
