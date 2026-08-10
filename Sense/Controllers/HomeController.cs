using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.Product.Queries.LoadProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sense.Performance;

namespace Sense.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly StorefrontDataCache _storefrontData;

        public HomeController(IMediator mediator, StorefrontDataCache storefrontData)
        {
            _mediator = mediator;
            _storefrontData = storefrontData;
        }

        private async Task<PagedList<ProductTbl>> GetPagedProductsAsync(string? searchTerm, int? ProductCategoryId, int? ProductBrandId, int? ProductModelId, int pageNumber, int pageSize)
        {
            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Clamp(pageSize, 1, 50);

            var productsResult = await _mediator.Send(new LoadProductsQuery { PublishedOnly = true });
            var query = productsResult.Data?.AsNoTracking();

            if (query == null)
            {
                return new PagedList<ProductTbl>(new List<ProductTbl>(), 0, pageNumber, pageSize);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Name != null && EF.Functions.Like(p.Name, $"%{searchTerm}%"));
            }

            if (ProductCategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == ProductCategoryId);
            }

            if (ProductBrandId.HasValue)
            {
                query = query.Where(p => p.BrandId == ProductBrandId);
            }

            if (ProductModelId.HasValue)
            {
                query = query.Where(p => p.ModelId == ProductModelId);
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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

            return new PagedList<ProductTbl>(items, totalCount, pageNumber, pageSize);
        }

        public async Task<IActionResult> Index(string? searchTerm, int? ProductCategoryId, int? ProductBrandId, int? ProductModelId, int pageSize = 10)
        {
            var banner = await _storefrontData.GetBannerAsync();

            var pagedProducts = await GetPagedProductsAsync(searchTerm, ProductCategoryId, ProductBrandId, ProductModelId, 1, pageSize);

            var cashbackOffers = await _storefrontData.GetCashbackOffersAsync();

            ViewBag.Products = pagedProducts;
            ViewBag.CashbackOffers = cashbackOffers;

            ViewBag.SearchTerm = searchTerm;
            ViewBag.ProductCategoryId = ProductCategoryId;
            ViewBag.ProductBrandId = ProductBrandId;
            ViewBag.ProductModelId = ProductModelId;

            return View(banner);
        }

        [HttpGet]
        public async Task<IActionResult> LoadMoreProducts(string? searchTerm, int? ProductCategoryId, int? ProductBrandId, int? ProductModelId, int pageNumber = 1, int pageSize = 10)
        {
            var pagedProducts = await GetPagedProductsAsync(searchTerm, ProductCategoryId, ProductBrandId, ProductModelId, pageNumber, pageSize);

            Response.Headers["X-Has-Next-Page"] = pagedProducts.MetaData.HasNext.ToString();
            return PartialView("~/Views/Shared/PartialViews/_ProductCards.cshtml", pagedProducts.AsEnumerable());
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            var branches = await _mediator.Send(new GetAllBranchesQuery());
            var setting = await _storefrontData.GetCenterSettingAsync();
            ViewBag.Branches = branches.Data;
            ViewBag.Setting = setting;
            return View();
        }

        [HttpGet]
        public IActionResult Instructions()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
