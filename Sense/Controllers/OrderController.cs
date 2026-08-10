using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.CouponDTOs;
using Sense.Application.DTOs.OrderDTOs;
using Sense.Application.UseCases.Address.Queries.GetMyAllAddressesQuery;
using Sense.Application.UseCases.CashbackOffer.Queries.GetActiveCashBackOfferQuery;
using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using Sense.Application.UseCases.Coupon.Commands.ApplyCouponCommand;
using Sense.Application.UseCases.Order.Commands.CreateOrderCommand;
using Sense.Application.UseCases.Order.Queries.GetOrderByIdQuery;
using Sense.Application.UseCases.Order.Queries.GetOrderDetailsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Sense.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        private ShoppingCartTbl? GetCartFromCookie()
        {
            if (HttpContext.Request.Cookies.TryGetValue("ShoppingCart", out var cartJson))
            {
                return JsonSerializer.Deserialize<ShoppingCartTbl>(cartJson);
            }

            return null;
        }
        private void SaveCartToCookie(ShoppingCartTbl cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            HttpContext.Response.Cookies.Append("ShoppingCart", cartJson, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7),
                IsEssential = true,
                HttpOnly = true
            });
        }
        private void ClearAllItemsFromShoppingCart()
        {
            var cart = GetCartFromCookie() ?? new ShoppingCartTbl();

            cart.Items.Clear();

            SaveCartToCookie(cart);

        }
        [HttpPost]
        public async Task<IActionResult> CheckOut([FromBody] OrderForCreateDto dto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = GetCartFromCookie() ?? new ShoppingCartTbl();
            var centerSetting = await _mediator.Send(new GetCenterSettingQuery { });
            dto.DeliveryFee = centerSetting.Data.DeliveryFee;
            var result = await _mediator.Send(new CreateOrderCommand { CurrentUserId = userId, ShoppingCart = cart, Dto = dto });
            if (result.Result.Code == ResultCodeStatus.Created)
            {
                ClearAllItemsFromShoppingCart();
                return Json(new { success = true, message = result.Result.Message, result.Data });
            }
            else
            {
                return Json(new { success = false, message = result.Result.Message, result.Data });
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Confirm(string? couponCode)
        {
            var isAuthenticated = User.Identity?.IsAuthenticated == true;

            // Guests can review their order; addresses are loaded only for signed-in users
            if (isAuthenticated)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var addressesResponse = await _mediator.Send(new GetMyAllAddressesQuery { CurrentUserId = userId });
                ViewBag.Addresses = addressesResponse.Data.ToList();
            }
            else
            {
                ViewBag.Addresses = null;
            }

            var centerSetting = await _mediator.Send(new GetCenterSettingQuery { });

            // Get shopping cart from cookie
            var cart = GetCartFromCookie() ?? new ShoppingCartTbl();
            decimal total = cart.Items.Sum(x => (x.ProductPrice ?? 0) * x.ProductQuantity);
            decimal deliveryFee = centerSetting.Data.DeliveryFee;
            var totalProducts = await _mediator.Send(new ApplyCouponCommand {Dto = new ApplyCouponDto { TotalAmount = total , CouponCode = couponCode} });
            var discount = totalProducts?.Data?.DiscountAmount ?? 0;
            // Pass via ViewBag
            ViewBag.TotalProducts = total - discount;
            ViewBag.DeliveryFee = deliveryFee;
            ViewBag.Total = total + deliveryFee;
            ViewBag.CouponCode = couponCode;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var orderDetails = await _mediator.Send(new GetOrderDetailsQuery { OrderId = id });
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            var cashBackOffer = await _mediator.Send(new GetActiveCashBackOfferQuery { OrderId = id });

            ViewBag.Order = order.Data;
            ViewBag.CashBackOffer = cashBackOffer.Data;

            return View(orderDetails.Data);
        }


    }
}
