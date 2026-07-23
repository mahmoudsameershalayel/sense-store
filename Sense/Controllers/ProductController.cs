using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.CouponDTOs;
using Sense.Application.DTOs.ShoppingCartDTOs;
using Sense.Application.UseCases.Address.Queries.GetAllAddressesQuery;
using Sense.Application.UseCases.Address.Queries.GetMyAllAddressesQuery;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Application.UseCases.Coupon.Commands.ApplyCouponCommand;
using Sense.Application.UseCases.Model.Queries.GetAllModelsQuery;
using Sense.Application.UseCases.Product.Queries.GetAllProductsQuery;
using Sense.Application.UseCases.Product.Queries.GetOtherProductsQuery;
using Sense.Application.UseCases.Product.Queries.GetProductByIdQuery;
using Sense.Application.UseCases.Product.Queries.LoadProductsQuery;
using Sense.Application.UseCases.ShoppingCart.Commands.AddItemToShoppingCartCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace Sense.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(string? searchTerm, int? ProductCategoryId, int? ProductBrandId, int? ProductModelId, int pageNumber = 1, int pageSize = 10)
        {

            var products = await _mediator.Send(new LoadProductsQuery { PublishedOnly = true });
            var query = products.Data;

            // Apply filters
            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(p => p.Name.ToString() == searchTerm);

            if (ProductCategoryId.HasValue)
                query = query.Where(p => p.CategoryId == ProductCategoryId);

            if (ProductBrandId.HasValue)
                query = query.Where(p => p.BrandId == ProductBrandId);

            if (ProductModelId.HasValue)
                query = query.Where(p => p.ModelId == ProductModelId);

            // Apply pagination
            var pagedProducts = PagedList<ProductTbl>.ToPagedList(query, pageNumber, pageSize);

            var categories = await _mediator.Send(new GetAllCategoriesQuery { });
            var brands = await _mediator.Send(new GetAllBrandsQuery { });

            ViewBag.Categories = categories.Data;
            ViewBag.Brands = brands.Data;

            // Filtering Query
            ViewBag.SearchTerm = searchTerm;
            ViewBag.ProductCategoryId = ProductCategoryId;
            ViewBag.ProductBrandId = ProductBrandId;
            ViewBag.ProductModelId = ProductModelId;


            return View(pagedProducts);
        }

      

        [HttpGet]
        public IActionResult Wishlist()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByIds(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                return PartialView("~/Views/Shared/PartialViews/_ProductCards.cshtml", new List<ProductTbl>());
            }

            var idList = ids.Split(',', StringSplitOptions.RemoveEmptyEntries)
                             .Select(s => int.TryParse(s, out var id) ? id : (int?)null)
                             .Where(id => id.HasValue)
                             .Select(id => id.Value)
                             .ToList();

            var productsResult = await _mediator.Send(new LoadProductsQuery { PublishedOnly = true });
            var query = productsResult.Data;

            var products = query == null
                ? new List<ProductTbl>()
                : await query
                    .Where(p => idList.Contains(p.Id))
                    .Select(p => new ProductTbl
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ImageURL = p.ImageURL,
                        Price = p.Price,
                        QuantityAvaliable = p.QuantityAvaliable,
                        CategoryId = p.CategoryId,
                        Category = p.Category == null ? null : new CategoryTbl { Name = p.Category.Name },
                        BrandId = p.BrandId,
                        ModelId = p.ModelId,
                        ProviderId = p.ProviderId,
                        Provider = p.Provider == null ? null : new ProviderTbl
                        {
                            DisplayName = p.Provider.DisplayName,
                            LogoURL = p.Provider.LogoURL ?? (p.Provider.ApplicationUser != null ? p.Provider.ApplicationUser.ImageURL : null)
                        }
                    })
                    .ToListAsync();

            return PartialView("~/Views/Shared/PartialViews/_ProductCards.cshtml", products.AsEnumerable());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
            var otherProducts = await _mediator.Send(new GetOtherProductsQuery { ProductId = id });
            if (product.Data is null || product.Data.Status != ProductStatus.Published)
                return NotFound();

            ViewBag.OtherProducts = otherProducts;

            return View(product.Data);
        }

        [HttpGet]
        public async Task<IActionResult> CartDetails()
        {
            var cart = GetCartFromCookie(HttpContext);

            if (cart == null || cart.Items == null || !cart.Items.Any())
            {
                // If no cart found, show empty cart
                return View(new ShoppingCartTbl());
            }
            /*
            // Prepare the updated cart summary
            var cartSummaryHtml = this.RenderPartialViewToString("_CartSummary", cart);
               */

            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var addresses = await _mediator.Send(new GetMyAllAddressesQuery { CurrentUserId = currentUserId });
            var centerSetting = await _mediator.Send(new GetCenterSettingQuery { });
            ViewBag.Addresses = addresses.Data;
            ViewBag.Total = cart.Items.Sum(i => i.ProductPrice * i.ProductQuantity).Value;
            ViewBag.DeliveryFee = centerSetting.Data.DeliveryFee;
            return View(cart);
        }

        [HttpGet]
        public async Task<IActionResult> GetCartSummary()
        {
            var cart = GetCartFromCookie(HttpContext) ?? new ShoppingCartTbl();
            var centerSetting = await _mediator.Send(new GetCenterSettingQuery());
            ViewBag.Total = cart.Items?.Sum(i => i.ProductPrice * i.ProductQuantity) ?? 0;
            ViewBag.DeliveryFee = centerSetting.Data.DeliveryFee;
            return PartialView("_CartSummary", cart);
        }

        [HttpGet]
        public IActionResult CartItemsNo()
        {
            var cart = GetCartFromCookie(HttpContext); // Get cart from cookie/session
            int itemCount = cart?.Items?.Count() ?? 0; // Get the total number of items in the cart

            return Json(new { itemCount });
        }


        /*  public string RenderPartialViewToString(string viewName, object model)
          {
              var controllerContext = this.ControllerContext;
              using (var sw = new StringWriter())
              {
                  var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                  var viewContext = new ViewContext(controllerContext, viewResult.View, new ViewDataDictionary(model), new TempDataDictionary(), sw);
                  viewResult.View.Render(viewContext, sw);
                  return sw.GetStringBuilder().ToString();
              }
          }  */
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var cart = GetCartFromCookie(HttpContext) ?? new ShoppingCartTbl();

            // Get product details
            var result = await _mediator.Send(new GetProductByIdQuery { ProductId = productId });
            var product = result.Data;

            // Check if product already exists in the cart
            var existingItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                // If product already exists, return error message
                return Json(new { success = false, message = "المنتج موجود يمكنك زيارة سلة التسوق وتغيير الكمية" });
            }

            // If product does not exist, add to the cart
            cart.Items.Add(new CartItemTbl
            {
                ProductId = productId,
                ProductQuantity = 1,
                ProductPrice = product.Price,
            });

            // Save cart back to cookie
            SaveCartToCookie(HttpContext, cart);

            return Json(new { success = true, message = "تم إضافة المنتج إلى السلة" });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            // Retrieve the cart from the cookie (or create a new one if none exists)
            var cart = GetCartFromCookie(HttpContext) ?? new ShoppingCartTbl();

            // Find the item in the cart and remove it
            var itemToRemove = cart.Items.FirstOrDefault(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);

                // Save the updated cart back to the cookie
                SaveCartToCookie(HttpContext, cart);

                // Return a success response
                return Json(new { success = true, message = "Product removed from cart" });
            }

            // If item wasn't found, return an error
            return Json(new { success = false, message = "Product not found in cart" });
        }

        private void SaveCartToCookie(HttpContext httpContext, ShoppingCartTbl cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            httpContext.Response.Cookies.Append("ShoppingCart", cartJson, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7),
                IsEssential = true,
                HttpOnly = true
            });
        }
        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] CartItemForUpdateDto dto)
        {
            var cart = GetCartFromCookie(HttpContext) ?? new ShoppingCartTbl();

            var item = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
            if (item == null)
            {
                return Json(new { success = false, message = "المنتج غير موجود في السلة" });
            }

            item.ProductQuantity = dto.ProductQuantity;
            SaveCartToCookie(HttpContext, cart);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon([FromBody] ApplyCouponDto dto)
        {
            var result = await _mediator.Send(new ApplyCouponCommand { Dto = dto });
            if (result.Result.Code != ResultCodeStatus.Success)
            {
                return Json(new
                {
                    success = false,
                    message = result.Result.Message
                });
            }


            return Json(new
            {
                success = true,
                originalTotal = dto.TotalAmount,
                originalTotalFormatted = dto.TotalAmount.ToString("C"),
                newTotal = result.Data.FinalAmount,
                newTotalFormatted = result.Data.FinalAmount.ToString("C"),
                discountAmount = result.Data.DiscountAmount,
                discountMessage = $"تم الخصم بمقدار {result.Data.DiscountAmount:C}"
            });
        }

        private ShoppingCartTbl? GetCartFromCookie(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies.TryGetValue("ShoppingCart", out var cartJson))
            {
                return JsonSerializer.Deserialize<ShoppingCartTbl>(cartJson);
            }

            return null;
        }

        public async Task<IActionResult> Promo(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
            if (result.Data == null) return NotFound();

            // عرض المنتج بطريقة مخصصة للحملة
            return View(result.Data);
        }

    }
}
