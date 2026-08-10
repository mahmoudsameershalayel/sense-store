using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.UploadCategoryImageCommand;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using Sense.Domain.Enums;
using Sense.Infrastructure;

namespace Sense.Areas.Provider.Controllers
{
    public class CategoryController : ProviderBaseController
    {
        private readonly IMediator _mediator;
        private readonly SenseDbContext _context;

        public CategoryController(IMediator mediator, SenseDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.ActiveMenu = "Categories";
            ViewData["title"] = "إدارة التصنيفات";

            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return View(result.Data ?? []);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryForCreateUpdateDto dto)
        {
            var name = dto.Name?.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                TempData["ErrorMessage"] = "اسم التصنيف مطلوب.";
                return RedirectToAction(nameof(Index));
            }

            if (await CategoryNameExistsAsync(name))
            {
                TempData["ErrorMessage"] = "يوجد تصنيف بهذا الاسم بالفعل.";
                return RedirectToAction(nameof(Index));
            }

            dto.Name = name;
            var result = await _mediator.Send(new CreateCategoryCommand { Dto = dto });
            SetResultMessage(result.Result?.Code == ResultCodeStatus.Created, result.Result?.Message);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryForCreateUpdateDto dto)
        {
            var name = dto.Name?.Trim();
            if (dto.Id <= 0 || string.IsNullOrWhiteSpace(name))
            {
                TempData["ErrorMessage"] = "بيانات التصنيف غير صالحة.";
                return RedirectToAction(nameof(Index));
            }

            if (await CategoryNameExistsAsync(name, dto.Id))
            {
                TempData["ErrorMessage"] = "يوجد تصنيف بهذا الاسم بالفعل.";
                return RedirectToAction(nameof(Index));
            }

            dto.Name = name;
            var result = await _mediator.Send(new UpdateCategoryCommand { Dto = dto });
            SetResultMessage(result.Result?.Code == ResultCodeStatus.Success, result.Result?.Message);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UploadImage(int id)
        {
            ViewBag.ActiveMenu = "Categories";
            ViewData["title"] = "صورة التصنيف";

            var category = await _context.CategoryTbls
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == id);

            if (category is null)
                return NotFound();

            ViewBag.CategoryName = category.Name;
            return View(new UploadCategoryImageDto { Id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImage(UploadCategoryImageDto dto)
        {
            if (!ModelState.IsValid || dto.Image is null)
            {
                TempData["ErrorMessage"] = "يرجى اختيار صورة صالحة للتصنيف.";
                return RedirectToAction(nameof(UploadImage), new { id = dto.Id });
            }

            var result = await _mediator.Send(new UploadCategoryImageCommand { Dto = dto });
            var succeeded = result.Result?.Code == ResultCodeStatus.Success;
            SetResultMessage(succeeded, result.Result?.Message);

            return succeeded
                ? RedirectToAction(nameof(Index))
                : RedirectToAction(nameof(UploadImage), new { id = dto.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _context.ProductTbls.AsNoTracking().AnyAsync(product => product.CategoryId == id))
            {
                TempData["ErrorMessage"] = "لا يمكن حذف التصنيف لأنه مستخدم في منتج واحد أو أكثر.";
                return RedirectToAction(nameof(Index));
            }

            var result = await _mediator.Send(new DeleteCategoryCommand { CategoryId = id });
            SetResultMessage(result.Result?.Code == ResultCodeStatus.Success, result.Result?.Message);
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> CategoryNameExistsAsync(string name, int? excludedId = null)
            => _context.CategoryTbls.AsNoTracking().AnyAsync(category =>
                category.Name == name && (!excludedId.HasValue || category.Id != excludedId.Value));

        private void SetResultMessage(bool succeeded, string? message)
        {
            TempData[succeeded ? "Message" : "ErrorMessage"] = message
                ?? (succeeded ? "تمت العملية بنجاح." : "تعذر إكمال العملية.");
        }
    }
}
