using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Sense.Services
{
    public interface IProviderRegistrationUploadService
    {
        Task<ProviderRegistrationUploadResult> SaveAsync(IFormFile document, CancellationToken cancellationToken = default);
        Task DeleteAsync(ProviderRegistrationStoredFile? file);
    }

    public sealed record ProviderRegistrationStoredFile(
        string StoredName,
        string OriginalName,
        string ContentType,
        long FileSize);

    public sealed record ProviderRegistrationUploadResult(
        bool Success,
        string Message,
        ProviderRegistrationStoredFile? File);

    public sealed class ProviderRegistrationUploadService : IProviderRegistrationUploadService
    {
        public const long MaxDocumentFileSize = 10L * 1024 * 1024;
        private const string DirectoryName = "ProviderDocuments";

        private static readonly HashSet<string> AllowedExtensions = new(StringComparer.OrdinalIgnoreCase)
        {
            ".pdf", ".png", ".jpg", ".jpeg"
        };

        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ProviderRegistrationUploadService> _logger;

        public ProviderRegistrationUploadService(
            IWebHostEnvironment environment,
            ILogger<ProviderRegistrationUploadService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<ProviderRegistrationUploadResult> SaveAsync(
            IFormFile document,
            CancellationToken cancellationToken = default)
        {
            var validationError = await ValidateAsync(document, cancellationToken);
            if (validationError is not null)
            {
                return Failed(validationError);
            }

            var extension = Path.GetExtension(document.FileName).ToLowerInvariant();
            var storedName = $"{Guid.NewGuid():N}{extension}";
            var directory = Path.Combine(_environment.ContentRootPath, "App_Data", DirectoryName);
            var path = Path.Combine(directory, storedName);

            try
            {
                Directory.CreateDirectory(directory);
                await using var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write, FileShare.None);
                await document.CopyToAsync(stream, cancellationToken);

                return new ProviderRegistrationUploadResult(
                    true,
                    string.Empty,
                    new ProviderRegistrationStoredFile(
                        storedName,
                        SanitizeOriginalName(document.FileName, extension),
                        GetContentType(extension),
                        document.Length));
            }
            catch (OperationCanceledException)
            {
                TryDelete(path);
                throw;
            }
            catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
            {
                _logger.LogError(exception, "Could not store a provider verification document.");
                TryDelete(path);
                return Failed("تعذر حفظ وثيقة التحقق. يرجى المحاولة مرة أخرى.");
            }
        }

        public Task DeleteAsync(ProviderRegistrationStoredFile? file)
        {
            if (file is null)
            {
                return Task.CompletedTask;
            }

            var safeStoredName = Path.GetFileName(file.StoredName);
            var path = Path.Combine(_environment.ContentRootPath, "App_Data", DirectoryName, safeStoredName);
            TryDelete(path);
            return Task.CompletedTask;
        }

        private static ProviderRegistrationUploadResult Failed(string message)
            => new(false, message, null);

        private static async Task<string?> ValidateAsync(IFormFile file, CancellationToken cancellationToken)
        {
            if (file.Length <= 0)
            {
                return "وثيقة التحقق فارغة.";
            }

            if (file.Length > MaxDocumentFileSize)
            {
                return "يجب ألا يتجاوز حجم وثيقة التحقق 10 ميجابايت.";
            }

            var extension = Path.GetExtension(file.FileName);
            if (!AllowedExtensions.Contains(extension))
            {
                return "صيغة وثيقة التحقق غير مدعومة. الصيغ المتاحة: PDF وPNG وJPG.";
            }

            if (!await HasExpectedSignatureAsync(file, extension, cancellationToken))
            {
                return "محتوى وثيقة التحقق لا يطابق امتداد الملف.";
            }

            return null;
        }

        private static async Task<bool> HasExpectedSignatureAsync(
            IFormFile file,
            string extension,
            CancellationToken cancellationToken)
        {
            var header = new byte[12];
            await using var stream = file.OpenReadStream();
            var read = await stream.ReadAsync(header.AsMemory(0, header.Length), cancellationToken);

            return extension.ToLowerInvariant() switch
            {
                ".pdf" => read >= 5
                    && header[0] == 0x25 && header[1] == 0x50 && header[2] == 0x44
                    && header[3] == 0x46 && header[4] == 0x2D,
                ".png" => read >= 8
                    && header.AsSpan(0, 8).SequenceEqual(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }),
                ".jpg" or ".jpeg" => read >= 3
                    && header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF,
                _ => false
            };
        }

        private static string GetContentType(string extension) => extension switch
        {
            ".pdf" => "application/pdf",
            ".png" => "image/png",
            ".jpg" or ".jpeg" => "image/jpeg",
            _ => "application/octet-stream"
        };

        private static string SanitizeOriginalName(string originalName, string extension)
        {
            var fileName = new string(Path.GetFileName(originalName)
                .Where(character => !char.IsControl(character))
                .ToArray())
                .Trim();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return $"document{extension}";
            }

            if (fileName.Length <= 255)
            {
                return fileName;
            }

            var baseName = Path.GetFileNameWithoutExtension(fileName);
            var allowedBaseLength = Math.Max(1, 255 - extension.Length);
            return $"{baseName[..Math.Min(baseName.Length, allowedBaseLength)]}{extension}";
        }

        private void TryDelete(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception exception) when (exception is IOException or UnauthorizedAccessException)
            {
                _logger.LogWarning(exception, "Could not clean up provider document {Path}.", path);
            }
        }
    }
}
