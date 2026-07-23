using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Domain.Migrations;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.InventoryDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Brand.Commands.UpdateBrandCommand;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.Cateogry.Commands.CreateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.DeleteCategoryCommand;
using Sense.Application.UseCases.Cateogry.Commands.UpdateCategoryCommand;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using Sense.Application.UseCases.Inventory.Commands.MakeInventoryActionCommand;
using Sense.Application.UseCases.Model.Queries.GetAllModelsQuery;
using Sense.Application.UseCases.Product.Commands.ChangeProductStatusCommand;
using Sense.Application.UseCases.Product.Commands.CreateProductCommand;
using Sense.Application.UseCases.Product.Commands.DeleteProductCommand;
using Sense.Application.UseCases.Provider.Queries.GetAllProvidersQuery;
using Sense.Application.UseCases.Product.Commands.UpdateProductCommand;
using Sense.Application.UseCases.Product.Commands.UpdateProductStockCommand;
using Sense.Application.UseCases.Product.Commands.UploadProductImageCommand;
using Sense.Application.UseCases.Product.Queries.GetAllProductsQuery;
using Sense.Application.UseCases.Product.Queries.GetBestSellerItemsQuery;
using Sense.Application.UseCases.Product.Queries.GetOutOfStockItemsQuery;
using Sense.Application.UseCases.Product.Queries.GetProductByIdQuery;
using Sense.Application.UseCases.Product.Queries.GetWorstSellerItemsQuery;
using Sense.Application.UseCases.Product.Queries.LoadProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Sense.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private static string BuildStatusBadge(ProductStatus status)
            => status switch
            {
                ProductStatus.Draft => "<span class='badge badge-light-secondary'>مسودة</span>",
                ProductStatus.PendingReview => "<span class='badge badge-light-warning'>بإنتظار المراجعة</span>",
                ProductStatus.Approved => "<span class='badge badge-light-info'>مقبول</span>",
                ProductStatus.Rejected => "<span class='badge badge-light-danger'>مرفوض</span>",
                ProductStatus.Published => "<span class='badge badge-light-success'>منشور</span>",
                ProductStatus.Unpublished => "<span class='badge badge-light-dark'>غير منشور</span>",
                ProductStatus.Archived => "<span class='badge badge-dark'>مؤرشف</span>",
                _ => "<span class='badge badge-light'>-</span>"
            };
        public async Task<IActionResult> Index(ProductParameters? productParameters)
        {
            var result = await _mediator.Send(new GetAllProductsQuery { ProductParameters = productParameters });

            var categories = await _mediator.Send(new GetAllCategoriesQuery { });

            ViewBag.Categories = categories.Data;

            var items = result.Data;

            ViewBag.ActiveMenu = "Product";
            ViewData["title"] = "المنتجات";
            return View(items);
        }
        [HttpGet("/Admin/Product/GetProductById/{id}")]
        [SwaggerOperation(Summary = "Get an Product by ID", Description = "Fetches the details of an Product by its ID.")]
        [SwaggerResponse(200, "Returns the Product details")]
        [SwaggerResponse(404, "Product not found")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetProductByIdQuery { ProductId = id };
            var result = await _mediator.Send(query);
            return StatusCode((int)result.Result.Code, result);
        }


        [HttpPost]
        public async Task<IActionResult> LoadProducts()
        {
            // DataTables
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            // Filters
            var categoryId = Request.Form["CategoryId"].FirstOrDefault();
            var statusFilter = Request.Form["Status"].FirstOrDefault();

            var result = await _mediator.Send(new LoadProductsQuery { });
            var query = result.Data;

            // Apply filters
            if (!string.IsNullOrEmpty(categoryId))
                query = query.Where(p => p.CategoryId.ToString() == categoryId);

            if (!string.IsNullOrEmpty(statusFilter) && Enum.TryParse<ProductStatus>(statusFilter, out var parsedStatus))
                query = query.Where(p => p.Status == parsedStatus);

            // Search
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(p =>
                    p.Name.Contains(searchValue) ||
                    p.Category.Name.Contains(searchValue)
                );
            }

            var recordsTotal = await query.CountAsync();

            var rows = await query
                     .OrderByDescending(p => p.CreatedAt)
                     .Skip(start)
                     .Take(length)
                     .Select(p => new
                     {
                         p.Id,
                         p.Name,
                         p.Description,
                         p.ImageURL,
                         CategoryName = p.Category.Name,
                         p.Price,
                         p.QuantityAvaliable,
                         p.CategoryId,
                         p.IsSparePart,
                         p.CreatedAt,
                         p.Status,
                         p.ProviderId,
                         ProviderName = p.Provider != null ? p.Provider.DisplayName : null
                     })
                     .ToListAsync();

            var data = rows.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                description = p.Description,
                image = p.ImageURL,
                category = p.CategoryName,
                price = p.Price,
                quantity = p.QuantityAvaliable,
                categoryId = p.CategoryId,
                isSparePart = p.IsSparePart,
                createdAt = p.CreatedAt.Value.ToString("yyyy-MM-dd"),
                providerId = p.ProviderId,
                provider = p.ProviderName ?? "المتجر",
                statusValue = (int)p.Status,
                status = BuildStatusBadge(p.Status)
            }).ToList();

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            });
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery { });
            ViewBag.Categories = categories.Data;
            var providers = await _mediator.Send(new GetAllProvidersQuery { });
            ViewBag.Providers = providers.Data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _mediator.Send(new GetAllCategoriesQuery { });
                ViewBag.Categories = categories.Data;
                var providers = await _mediator.Send(new GetAllProvidersQuery { });
                ViewBag.Providers = providers.Data;
                return View(dto);
            }

            // Admin-created products are the quality gate themselves: go live immediately
            var result = await _mediator.Send(new CreateProductCommand { Dto = dto, InitialStatus = ProductStatus.Published });

            if (result.Result.Code != ResultCodeStatus.Created)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UploadImage(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadProductImageDto dto)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(new UploadProductImageCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return RedirectToAction("Index");
        }

        [HttpPut("/Admin/Product/Edit/{productId}")]
        public async Task<IActionResult> Edit(int productId, [FromBody] ProductForCreateUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var command = new UpdateProductCommand { ProductId = productId, Dto = dto };
            var result = await _mediator.Send(command);

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return Ok(new { id = productId, data = result.Data ,message = "Updated Successfully" });
        }


        [HttpPut("/Admin/Product/update-stock")]
        public async Task<IActionResult> UpdateStock([FromBody] ProductStockForUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var command = new UpdateProductStockCommand { Dto = dto };
            var result = await _mediator.Send(command);

            if (result.Result.Code != ResultCodeStatus.Success && result.Result.Code != ResultCodeStatus.Created)
            {
                return BadRequest(result.Result.Message);
            }

            return Ok(new { id = dto.ItemId, data = result.Data, message = "تم تحديث المخزون بنجاح" });
        }

        [HttpGet("/Admin/Product/best-seller")]
        public async Task<IActionResult> GetBestSellerItems()
        {
            var result = await _mediator.Send(new GetBestSellerItemsQuery { });
            return StatusCode((int)result.Result.Code, result);
        }

        [HttpGet("/Admin/Product/worst-seller")]
        public async Task<IActionResult> GetWorstSellerItems()
        {
            var result = await _mediator.Send(new GetWorstSellerItemsQuery {  });
            return StatusCode((int)result.Result.Code, result);
        }


        [HttpGet("/Admin/Product/out-of-stock")]
        public async Task<IActionResult> GetOutOfStockItems()
        {
            var result = await _mediator.Send(new GetOutOfStockItemsQuery { });
            return StatusCode((int)result.Result.Code, result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, ProductStatus status)
        {
            var result = await _mediator.Send(new ChangeProductStatusCommand { ProductId = id, TargetStatus = status });

            if (result.Result.Code != ResultCodeStatus.Success)
                return Json(new { success = false, message = result.Result.Message });

            return Json(new { success = true, id = id, message = result.Result.Message });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand { ProductId = id });

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                TempData["ErrorMessage"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = result.Result.Message;
            return Json(new { id = id, message = "Deleted Successfully" });

        }

      

    }
}
