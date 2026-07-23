using Sense.Domain.Enums;
using Sense.Application.DTOs.InventoryDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Inventory.Commands.ApplyInventoryActionCommand;
using Sense.Application.UseCases.Inventory.Commands.MakeInventoryActionCommand;
using Sense.Application.UseCases.Inventory.Queries.GetAllInventoryActionLogsQuery;
using Sense.Application.UseCases.Product.Queries.GetAllProductsQuery;
using Sense.Application.UseCases.Product.Queries.GetBestSellerItemsQuery;
using Sense.Application.UseCases.Product.Queries.GetOutOfStockItemsQuery;
using Sense.Application.UseCases.Product.Queries.GetWorstSellerItemsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sense.Areas.Admin.Controllers
{
    public class InventoryController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllInventoryActionLogsQuery());
            var allProducts = await _mediator.Send(new GetAllProductsQuery());
            ViewBag.Products = allProducts.Data;
            ViewBag.ActiveMenu = "Inventory";
            return View(result.Data);
        }

        public async Task<IActionResult> ManageInventory(int? year, int? month)
        {

            var bestSeller = await _mediator.Send(new GetBestSellerItemsQuery
            {
                Year = year,
                Month = month
            });
            var worstSeller = await _mediator.Send(new GetWorstSellerItemsQuery
            {
                Year = year,
                Month = month
            });
            var outOfStock = await _mediator.Send(new GetOutOfStockItemsQuery());

            ViewBag.BestSeller = bestSeller.Data ?? new List<ProductDto>();
            ViewBag.WorstSeller = worstSeller.Data ?? new List<ProductDto>();
            ViewBag.OutOfStock = outOfStock.Data ?? new List<ProductDto>();
            ViewBag.Year = year;
            ViewBag.Month = month;

            ViewBag.ActiveMenu = "ManageInventory";
            ViewData["Title"] = "تقارير المنتجات";
            return View();
        }

        public async Task<IActionResult> GetSellers(int? year, int? month)
        {
            var bestSeller = await _mediator.Send(new GetBestSellerItemsQuery
            {
                Year = year,
                Month = month
            });
            var worstSeller = await _mediator.Send(new GetWorstSellerItemsQuery
            {
                Year = year,
                Month = month
            });

            return Json(new
            {
                bestSeller = bestSeller.Data ?? new List<ProductDto>(),
                worstSeller = worstSeller.Data ?? new List<ProductDto>()
            });
        }
        

        [HttpPost]
        public async Task<IActionResult> MakeInventoryAction([FromBody]InventoryActionForCreateDto dto)
        {
            var result = await _mediator.Send(new MakeInventoryActionCommand { Dto = dto});
            return StatusCode((int)result.Result.Code, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAction([FromBody] InventoryActionForCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data");
            var result = await _mediator.Send(new MakeInventoryActionCommand { Dto = dto });
            if(result.Result.Code == ResultCodeStatus.Success || result.Result.Code == ResultCodeStatus.Created)
                return Ok(new { success = true, message = "تمت إضافة الحركة بنجاح" });
            else
                return BadRequest(new { success = false, message = "فشلت عملية الإضافة" });

        }

    }
}
