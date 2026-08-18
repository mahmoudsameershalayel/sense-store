using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sense.Application.Abstractions;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Infrastructure;
using Sense.Models.ProviderRegistration;

namespace Sense.Controllers
{
    [AllowAnonymous]
    public class ProviderRegistrationController : Controller
    {
        private const long MaximumProfileImageSize = 5 * 1024 * 1024;
        private const string RestaurantCategoryKey = "restaurant";
        private const string RestaurantTemplateKey = "restaurant-modern";

        private readonly SenseDbContext _context;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IImageServices _imageServices;
        private readonly IHtmlSanitizer _htmlSanitizer;
        private readonly ILogger<ProviderRegistrationController> _logger;

        public ProviderRegistrationController(
            SenseDbContext context,
            UserManager<ApplicationUserTbl> userManager,
            IImageServices imageServices,
            IHtmlSanitizer htmlSanitizer,
            ILogger<ProviderRegistrationController> logger)
        {
            _context = context;
            _userManager = userManager;
            _imageServices = imageServices;
            _htmlSanitizer = htmlSanitizer;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string? categoryKey,
            string? templateKey,
            CancellationToken cancellationToken)
        {
            var category = await ResolveCategoryAsync(categoryKey, cancellationToken);
            if (!string.IsNullOrWhiteSpace(categoryKey) && category is null)
                return RedirectToAction(nameof(ChooseCategory));

            if (!string.IsNullOrWhiteSpace(templateKey)
                && (category is null || !category.IsRestaurant || templateKey != RestaurantTemplateKey))
            {
                return RedirectToAction(nameof(Templates), new { categoryKey });
            }

            return View(new ProviderRegistrationViewModel
            {
                BusinessCategoryKey = category?.Key,
                BusinessCategoryName = category?.Name,
                StorefrontTemplateKey = templateKey
            });
        }

        [HttpGet]
        public async Task<IActionResult> ChooseCategory(CancellationToken cancellationToken)
        {
            var categories = await _context.CategoryTbls
                .AsNoTracking()
                .Where(category => !category.IsDeleted && category.IsActive)
                .OrderBy(category => category.Name)
                .Select(category => new ProviderCategoryChoiceViewModel
                {
                    Key = $"category-{category.Id}",
                    Name = category.Name ?? "تصنيف بدون اسم",
                    ImageUrl = category.ImageURL,
                    IsRestaurant = category.Name != null
                        && (category.Name.Contains("مطعم") || category.Name.Contains("مطاعم"))
                })
                .ToListAsync(cancellationToken);

            if (!categories.Any(category => category.IsRestaurant))
            {
                categories.Insert(0, new ProviderCategoryChoiceViewModel
                {
                    Key = RestaurantCategoryKey,
                    Name = "المطاعم",
                    IsRestaurant = true
                });
            }

            return View(new ProviderCategorySelectionViewModel { Categories = categories });
        }

        [HttpGet]
        public async Task<IActionResult> Templates(string categoryKey, CancellationToken cancellationToken)
        {
            var category = await ResolveCategoryAsync(categoryKey, cancellationToken);
            if (category is null)
                return RedirectToAction(nameof(ChooseCategory));

            var templates = category.IsRestaurant
                ? new[]
                {
                    new ProviderTemplateChoiceViewModel
                    {
                        Key = RestaurantTemplateKey,
                        Name = "مطعم عصري",
                        Description = "واجهة طلب سريعة مع عروض بارزة، أقسام قائمة الطعام، وبطاقات منتجات واضحة."
                    }
                }
                : Array.Empty<ProviderTemplateChoiceViewModel>();

            return View(new ProviderTemplateSelectionViewModel
            {
                CategoryKey = category.Key,
                CategoryName = category.Name,
                Templates = templates
            });
        }

        [HttpGet]
        public async Task<IActionResult> RestaurantPreview(
            string categoryKey = RestaurantCategoryKey,
            CancellationToken cancellationToken = default)
        {
            var category = await ResolveCategoryAsync(categoryKey, cancellationToken);
            if (category is null || !category.IsRestaurant)
                return NotFound();

            ViewBag.CategoryKey = category.Key;
            return View();
        }

        [HttpGet]
        public IActionResult Terms() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(6 * 1024 * 1024)]
        public async Task<IActionResult> Index(
            ProviderRegistrationViewModel model,
            CancellationToken cancellationToken)
        {
            var category = await ResolveCategoryAsync(model.BusinessCategoryKey, cancellationToken);
            model.BusinessCategoryName = category?.Name;

            if (!string.IsNullOrWhiteSpace(model.BusinessCategoryKey) && category is null)
                ModelState.AddModelError(nameof(model.BusinessCategoryKey), "فئة النشاط المختارة غير صالحة.");

            if (!string.IsNullOrWhiteSpace(model.StorefrontTemplateKey)
                && (category is null || !category.IsRestaurant || model.StorefrontTemplateKey != RestaurantTemplateKey))
            {
                ModelState.AddModelError(nameof(model.StorefrontTemplateKey), "قالب المتجر المختار غير متاح لهذه الفئة.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var businessDescription = _htmlSanitizer.Sanitize(model.BusinessDescription).Trim();
            if (string.IsNullOrWhiteSpace(businessDescription))
            {
                ModelState.AddModelError(nameof(model.BusinessDescription), "وصف النشاط التجاري مطلوب.");
                return View(model);
            }

            model.BusinessDescription = businessDescription;

            var email = model.Email.Trim();
            if (await _userManager.FindByEmailAsync(email) is not null)
            {
                ModelState.AddModelError(nameof(model.Email), "يوجد حساب مسجل بهذا البريد الإلكتروني بالفعل.");
                return View(model);
            }

            var imageValidationError = await ValidateProfileImageAsync(model.ProfileImage, cancellationToken);
            if (imageValidationError is not null)
            {
                ModelState.AddModelError(nameof(model.ProfileImage), imageValidationError);
                return View(model);
            }

            var imageUrl = await _imageServices.UploadImageToFreeImageHost(model.ProfileImage!);
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                ModelState.AddModelError(nameof(model.ProfileImage), "تعذر حفظ صورة الملف الشخصي. يرجى اختيار صورة صالحة والمحاولة مرة أخرى.");
                return View(model);
            }

            try
            {
                await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

                var user = new ApplicationUserTbl
                {
                    Email = email,
                    UserName = email,
                    // OTP verification after registration is temporarily disabled.
                    EmailConfirmed = true,
                    FirstName = model.FullName.Trim(),
                    LastName = string.Empty,
                    CompName = model.BusinessName.Trim(),
                    PhoneNumber = model.PhoneNumber.Trim(),
                    UserType = UserType.Provider,
                    ImageURL = imageUrl,
                    IsActive = true
                };

                var createResult = await _userManager.CreateAsync(user, model.Password);
                if (!createResult.Succeeded)
                {
                    await transaction.RollbackAsync(CancellationToken.None);
                    await DeleteImageSafelyAsync(imageUrl);
                    AddIdentityErrors(createResult);
                    return View(model);
                }

                var roleResult = await _userManager.AddToRoleAsync(user, "Provider");
                if (!roleResult.Succeeded)
                {
                    await transaction.RollbackAsync(CancellationToken.None);
                    await DeleteImageSafelyAsync(imageUrl);
                    AddIdentityErrors(roleResult);
                    return View(model);
                }

                var provider = new ProviderTbl
                {
                    ApplicationUserId = user.Id,
                    DisplayName = model.BusinessName.Trim(),
                    Description = businessDescription,
                    LogoURL = imageUrl,
                    PhoneNumber = model.PhoneNumber.Trim(),
                    BusinessCategoryKey = category?.Key,
                    StorefrontTemplateKey = model.StorefrontTemplateKey,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };

                _context.ProviderTbls.Add(provider);
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (OperationCanceledException)
            {
                await DeleteImageSafelyAsync(imageUrl);
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Could not register provider account for {Email}.", email);
                await DeleteImageSafelyAsync(imageUrl);
                ModelState.AddModelError(string.Empty, "تعذر إنشاء حساب المزود. يرجى المحاولة مرة أخرى.");
                return View(model);
            }

            return RedirectToAction("Login", "Account");
        }

        private async Task<ProviderCategoryChoiceViewModel?> ResolveCategoryAsync(
            string? categoryKey,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(categoryKey))
                return null;

            if (string.Equals(categoryKey, RestaurantCategoryKey, StringComparison.OrdinalIgnoreCase))
            {
                return new ProviderCategoryChoiceViewModel
                {
                    Key = RestaurantCategoryKey,
                    Name = "المطاعم",
                    IsRestaurant = true
                };
            }

            const string prefix = "category-";
            if (!categoryKey.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
                || !int.TryParse(categoryKey[prefix.Length..], out var categoryId))
            {
                return null;
            }

            var category = await _context.CategoryTbls
                .AsNoTracking()
                .Where(item => item.Id == categoryId && !item.IsDeleted && item.IsActive)
                .Select(item => new { item.Id, item.Name, item.ImageURL })
                .FirstOrDefaultAsync(cancellationToken);

            if (category is null)
                return null;

            var categoryName = category.Name ?? "تصنيف بدون اسم";
            return new ProviderCategoryChoiceViewModel
            {
                Key = $"category-{category.Id}",
                Name = categoryName,
                ImageUrl = category.ImageURL,
                IsRestaurant = categoryName.Contains("مطعم") || categoryName.Contains("مطاعم")
            };
        }

        private void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private async Task DeleteImageSafelyAsync(string imageUrl)
        {
            try
            {
                await _imageServices.DeleteImage(imageUrl);
            }
            catch (Exception exception)
            {
                _logger.LogWarning(exception, "Could not delete unused provider profile image {ImageUrl}.", imageUrl);
            }
        }

        private static async Task<string?> ValidateProfileImageAsync(
            IFormFile? image,
            CancellationToken cancellationToken)
        {
            if (image is null || image.Length == 0)
            {
                return "صورة الملف الشخصي مطلوبة.";
            }

            if (image.Length > MaximumProfileImageSize)
            {
                return "يجب ألا يتجاوز حجم الصورة 5 ميجابايت.";
            }

            var extension = Path.GetExtension(image.FileName).ToLowerInvariant();
            var validContentType = extension switch
            {
                ".jpg" or ".jpeg" => image.ContentType.Equals("image/jpeg", StringComparison.OrdinalIgnoreCase),
                ".png" => image.ContentType.Equals("image/png", StringComparison.OrdinalIgnoreCase),
                ".webp" => image.ContentType.Equals("image/webp", StringComparison.OrdinalIgnoreCase),
                _ => false
            };

            if (!validContentType)
            {
                return "صيغة الصورة غير مدعومة. الصيغ المتاحة: JPG وPNG وWEBP.";
            }

            var header = new byte[12];
            await using var stream = image.OpenReadStream();
            var bytesRead = await stream.ReadAsync(header.AsMemory(0, header.Length), cancellationToken);

            var hasValidSignature = extension switch
            {
                ".jpg" or ".jpeg" => bytesRead >= 3
                    && header[0] == 0xFF
                    && header[1] == 0xD8
                    && header[2] == 0xFF,
                ".png" => bytesRead >= 8
                    && header[0] == 0x89
                    && header[1] == 0x50
                    && header[2] == 0x4E
                    && header[3] == 0x47
                    && header[4] == 0x0D
                    && header[5] == 0x0A
                    && header[6] == 0x1A
                    && header[7] == 0x0A,
                ".webp" => bytesRead >= 12
                    && header[0] == 0x52
                    && header[1] == 0x49
                    && header[2] == 0x46
                    && header[3] == 0x46
                    && header[8] == 0x57
                    && header[9] == 0x45
                    && header[10] == 0x42
                    && header[11] == 0x50,
                _ => false
            };

            return hasValidSignature ? null : "محتوى ملف الصورة غير صالح.";
        }
    }
}
