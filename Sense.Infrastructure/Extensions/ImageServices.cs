using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Sense.Application.Abstractions;
using Sense.Application.DomainEntities;
using Sense.Domain.Enums;

namespace Sense.Infrastructure.Extensions
{
    public class ImageServices : IImageServices
    {
        private static readonly HashSet<string> AllowedExtensions = new(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".gif", ".webp"
        };

        private readonly IWebHostEnvironment _environment;

        public ImageServices(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string? GeneratePublicUrl(string? fullPath)
        {
            return GenerateRelativePath(fullPath);
        }

        public string? GenerateRelativePath(string? fullPath)
        {
            if (string.IsNullOrWhiteSpace(fullPath))
            {
                return null;
            }

            if (fullPath.StartsWith('/'))
            {
                return fullPath.Replace('\\', '/');
            }

            var webRootPath = GetWebRootPath();
            var normalizedFullPath = Path.GetFullPath(fullPath);
            var normalizedWebRoot = EnsureTrailingSeparator(Path.GetFullPath(webRootPath));

            if (!normalizedFullPath.StartsWith(normalizedWebRoot, StringComparison.OrdinalIgnoreCase))
            {
                return fullPath.Replace('\\', '/');
            }

            var relativePath = Path.GetRelativePath(normalizedWebRoot, normalizedFullPath).Replace('\\', '/');
            return $"/{relativePath}";
        }

        public async Task<string> UploadImageToFreeImageHost(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return string.Empty;
            }

            var extension = Path.GetExtension(imageFile.FileName);
            if (string.IsNullOrWhiteSpace(extension) || !AllowedExtensions.Contains(extension))
            {
                return string.Empty;
            }

            var uploadsDirectory = Path.Combine(GetWebRootPath(), "uploads", "images");
            Directory.CreateDirectory(uploadsDirectory);

            var fileName = $"{Guid.NewGuid():N}{extension.ToLowerInvariant()}";
            var filePath = Path.Combine(uploadsDirectory, fileName);

            await using var stream = new FileStream(filePath, FileMode.CreateNew);
            await imageFile.CopyToAsync(stream);

            return $"/uploads/images/{fileName}";
        }

        public Task<ResponseResult<bool>> DeleteImage(string imageUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(imageUrl))
                {
                    return Task.FromResult(ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, "No image to delete."));
                }

                var relativePath = GetRelativePathFromUrl(imageUrl);
                if (string.IsNullOrWhiteSpace(relativePath))
                {
                    return Task.FromResult(ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, "External image skipped."));
                }

                var webRootPath = GetWebRootPath();
                var fullPath = Path.GetFullPath(Path.Combine(webRootPath, relativePath.TrimStart('/', '\\')));
                var normalizedWebRoot = EnsureTrailingSeparator(Path.GetFullPath(webRootPath));

                if (!fullPath.StartsWith(normalizedWebRoot, StringComparison.OrdinalIgnoreCase))
                {
                    return Task.FromResult(ResponseResult<bool>.GetResult(ResultCodeStatus.Failed, false, "Invalid image path."));
                }

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                return Task.FromResult(ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, "Image deleted successfully."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(ResponseResult<bool>.GetResult(ResultCodeStatus.Failed, false, $"An error occurred while deleting the image: {ex.Message}"));
            }
        }

        private string GetWebRootPath()
        {
            if (!string.IsNullOrWhiteSpace(_environment.WebRootPath))
            {
                return _environment.WebRootPath;
            }

            return Path.Combine(_environment.ContentRootPath, "wwwroot");
        }

        private static string EnsureTrailingSeparator(string path)
        {
            return path.EndsWith(Path.DirectorySeparatorChar) ? path : path + Path.DirectorySeparatorChar;
        }

        private static string? GetRelativePathFromUrl(string imageUrl)
        {
            if (Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri))
            {
                return uri.LocalPath.StartsWith("/uploads/images/", StringComparison.OrdinalIgnoreCase)
                    ? uri.LocalPath
                    : null;
            }

            return imageUrl.StartsWith("/uploads/images/", StringComparison.OrdinalIgnoreCase)
                ? imageUrl
                : null;
        }
    }
}