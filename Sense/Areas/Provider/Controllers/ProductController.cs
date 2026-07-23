using Sense.Domain.Enums;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using Sense.Application.UseCases.Product.Commands.ChangeProductStatusCommand;
using Sense.Application.UseCases.Product.Commands.CreateProductCommand;
using Sense.Application.UseCases.Product.Commands.UpdateProductCommand;
using Sense.Application.UseCases.Product.Commands.UploadProductImageCommand;
using Sense.Application.UseCases.Product.Queries.GetProductByIdQuery;
using Sense.Application.UseCases.Product.Queries.LoadProductsQuery;
using Sense.Application.UseCases.Provider.Queries.GetProviderByUserIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Sense.Areas.Provider.Controllers
{
    public class ProductController : ProviderBaseController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private async Task<Sense.Application.DTOs.ProviderDTOs.ProviderDto?> GetCurrentProvider()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new GetProviderByUserIdQuery { CurrentUserId = userId });
            return result.Data;
        }

        public async Task<IActionResult> Index()
        {
            var provider = await GetCurrentProvider();
            if (provider is null)
                return Forbid();

            var result = await _mediator.Send(new LoadProductsQuery { ProviderId = provider.Id });
            var products = await result.Data.OrderByDescending(p => p.CreatedAt).ToListAsync();

            ViewBag.ProviderName = provider.DisplayName;
            ViewData["title"] = "منتجاتي";
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery { });
            ViewBag.Categories = categories.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductForCreateUpdateDto dto)
        {
            var provider = await GetCurrentProvider();
            if (provider is null)
                return Forbid();

            if (!ModelState.IsValid)
            {
                var categories = await _mediator.Send(new GetAllCategoriesQuery { });
                ViewBag.Categories = categories.Data;
                return View(dto);
            }

            // Provider submissions always start as their own Draft
            dto.ProviderId = provider.Id;
            var result = await _mediator.Send(new CreateProductCommand { Dto = dto, InitialStatus = ProductStatus.Draft });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = "تم حفظ المنتج كمسودة. ارفع صورة المنتج ثم أرسله للمراجعة.";
            return RedirectToAction(nameof(UploadImage), new { id = result.Data.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var provider = await GetCurrentProvider();
            if (provider is null)
                return Forbid();

            var result = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
            var product = result.Data;

            if (product is null || product.ProviderId != provider.Id)
                return NotFound();

            if (product.Status != ProductStatus.Draft && product.Status != ProductStatus.Rejected)
            {
                TempData["ErrorMessage"] = "لا يمكن تعديل المنتج إلا وهو مسودة أو مرفوض.";
                return RedirectToAction(nameof(Index));
            }

            var categories = await _mediator.Send(new GetAllCategoriesQuery { });
            ViewBag.Categories = categories.Data;
            ViewBag.ProductId = id;

            var dto = new ProductForCreateUpdateDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                QuantityAvaliable = product.QuantityAvaliable,
                IsSparePart = product.IsSparePart,
                CategoryId = product.Category?.Id,
                BrandId = product.Brand?.Id,
                ModelId = product.Model?.Id,
                ProviderId = product.ProviderId
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductForCreateUpdateDto dto)
        {
            var provider = await GetCurrentProvider();
            if (provider is null)
                return Forbid();

            var existing = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
            var product = existing.Data;

            if (product is null || product.ProviderId != provider.Id)
                return NotFound();

            if (product.Status != ProductStatus.Draft && product.Status != ProductStatus.Rejected)
            {
                TempData["ErrorMessage"] = "لا يمكن تعديل المنتج إلا وهو مسودة أو مرفوض.";
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                var categories = await _mediator.Send(new GetAllCategoriesQuery { });
                ViewBag.Categories = categories.Data;
                ViewBag.ProductId = id;
                return View(dto);
            }

            dto.ProviderId = provider.Id;
            var result = await _mediator.Send(new UpdateProductCommand { ProductId = id, Dto = dto });

            if (result.Result.Code != ResultCodeStatus.Success)
                TempData["ErrorMessage"] = result.Result.Message;
            else
                TempData["Message"] = "تم تحديث المنتج بنجاح.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UploadImage(int id)
        {
            var provider = await GetCurrentProvider();
            if (provider is null)
                return Forbid();

            var result = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
            if (result.Data is null || result.Data.ProviderId != provider.Id)
                return NotFound();

            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadProductImageDto dto)
        {
            var provider = await GetCurrentProvider();
            if (provider is null)
                return Forbid();

            var existing = await _mediator.Send(new GetProductByIdQuery { ProductId = dto.Id });
            if (existing.Data is null || existing.Data.ProviderId != provider.Id)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Id = dto.Id;
                return View();
            }

            var result = await _mediator.Send(new UploadProductImageCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Submit(int id)
        {
            var provider = await GetCurrentProvider();
            if (provider is null)
                return Forbid();

            var result = await _mediator.Send(new ChangeProductStatusCommand
            {
                ProductId = id,
                TargetStatus = ProductStatus.PendingReview,
                ActingProviderId = provider.Id
            });

            if (result.Result.Code != ResultCodeStatus.Success)
                return Json(new { success = false, message = result.Result.Message });

            return Json(new { success = true, id = id, message = "تم إرسال المنتج للمراجعة." });
        }
    }
}
