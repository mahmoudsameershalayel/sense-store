using Microsoft.AspNetCore.Http;
using Sense.Application.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sense.Application.Abstractions
{
    public interface IImageServices
    {
        public string? GeneratePublicUrl(string? fullPath);
        public string? GenerateRelativePath(string? fullPath);
        public Task<string> UploadImageToFreeImageHost(IFormFile imageFile);
        public Task<ResponseResult<bool>> DeleteImage(string imageUrl);
    }
}
