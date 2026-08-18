using Sense.Domain.DBEntities;
using Sense.Application.UseCases.Product.Queries.LoadProductsQuery;
using Sense.Application.UseCases.Provider.Queries.GetProviderByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Controllers
{
    // Public storefront pages for providers. Named "Providers" (plural) on purpose:
    // "/Provider/..." is captured by the Provider dashboard area route.
    public class ProvidersController : Controller
    {
        private readonly IMediator _mediator;
        public ProvidersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var providerResult = await _mediator.Send(new GetProviderByIdQuery { Id = id });
            var provider = providerResult.Data;

            if (provider is null || !provider.IsActive)
                return NotFound();

            var productsResult = await _mediator.Send(new LoadProductsQuery { PublishedOnly = true, ProviderId = id });
            var products = await productsResult.Data.OrderByDescending(p => p.CreatedAt).Select(p => new ProductTbl
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
            }).ToListAsync();

            ViewBag.Products = products;
            ViewData["title"] = provider.DisplayName;

            if (string.Equals(provider.StorefrontTemplateKey, "restaurant-modern", StringComparison.OrdinalIgnoreCase))
                return View("~/Views/Providers/Templates/Restaurant.cshtml", provider);

            return View(provider);
        }
    }
}
