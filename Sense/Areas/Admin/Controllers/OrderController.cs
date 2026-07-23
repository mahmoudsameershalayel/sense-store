using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DTOs.OrderDTOs;
using Sense.Infrastructure.Extensions;
using Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery;
using Sense.Application.UseCases.CashbackOffer.Queries.GetActiveCashBackOfferQuery;
using Sense.Application.UseCases.Order.Commands.UpdateOrderStatusCommand;
using Sense.Application.UseCases.Order.Queries.GetAllOrdersQuery;
using Sense.Application.UseCases.Order.Queries.GetOrderByIdQuery;
using Sense.Application.UseCases.Order.Queries.GetOrderDetailsQuery;
using Sense.Application.UseCases.Order.Queries.LoadOrdersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(OrderParameters? orderParameters)
        {
            var Orders = await _mediator.Send(new GetAllOrdersQuery {OrderParameters = orderParameters});

            ViewBag.TotalPages = Orders.Data.MetaData.TotalPages;
            ViewBag.CurrentPage = Orders.Data.MetaData.CurrentPage;

            ViewBag.ActiveMenu = "Orders";
            ViewData["title"] = "الطلبات";


            return View(Orders.Data);
        }

        [HttpPost]
        public async Task<IActionResult> LoadOrders()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            var sortColumnIndex = Convert.ToInt32(Request.Form["order[0][column]"]);
            var sortColumnName = Request.Form[$"columns[{sortColumnIndex}][data]"].FirstOrDefault();
            var sortDirection = Request.Form["order[0][dir]"].FirstOrDefault(); // asc or desc

            var status = Request.Form["status"].FirstOrDefault();
            var search = Request.Form["searchTerm"].FirstOrDefault();

            var result = await _mediator.Send(new LoadOrdersQuery { });
            var query = result.Data;
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.Id.ToString().Contains(search) ||
                    x.Customer.ApplicationUser.FirstName.Contains(search) ||
                    x.Customer.ApplicationUser.LastName.Contains(search)
                );
            }
            else if (!string.IsNullOrEmpty(status) && Enum.TryParse<OrderStatus>(status, out var orderStatus))
            {
                query = query.Where(x => x.OrderStatus == orderStatus);
            }

            var recordsTotal = await query.CountAsync();



            // بيانات الصفحة الحالية
            var data = await query.Skip(start).Take(length)
                .Select(x => new
                {
                    Id = x.Id,
                    OrderNumber = x.Id,
                    CustomerName = $"{x.Customer.ApplicationUser.FirstName} {x.Customer.ApplicationUser.LastName}",
                    customerPhoneNumber = x.Customer.ApplicationUser.PhoneNumber,
                    OrderDate = x.OrderDate.Value.ToString("yyyy-MM-dd"),
                    OrderTime = x.OrderDate.Value.ToString("HH:mm tt"),
                    OrderStatusValue = (int)x.OrderStatus,
                    OrderStatus = BadgeHelper.GetOrderStatusBadge(x.OrderStatus),
                    PaymentMethod = BadgeHelper.GetPaymentMethodBadge(x.PaymentMethod),
                    PaymentStatus = BadgeHelper.GetPaymentStatusBadge(x.PaymentStatus),
                })
                .ToListAsync();

            return Json(new
            {
                draw,
                recordsFiltered = recordsTotal,
                recordsTotal,
                data
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderCounts()
        {

            var result = await _mediator.Send(new LoadOrdersQuery { });
            var query = result.Data;
            var counts = new
            {
                New = await query.CountAsync(x => x.OrderStatus == OrderStatus.Pending || x.OrderStatus == OrderStatus.Rejected),
                Preparing = await query.CountAsync(x => x.OrderStatus == OrderStatus.Preparing || x.OrderStatus == OrderStatus.Prepared || x.OrderStatus == OrderStatus.OutForDelivery),
                Completed = await query.CountAsync(x => x.OrderStatus == OrderStatus.Deliverd || x.OrderStatus == OrderStatus.NotDeliverd)
            };

            return Ok(counts);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var orderDetails = await _mediator.Send(new GetOrderDetailsQuery { OrderId = id });
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            var cashBackOffer = await _mediator.Send(new GetActiveCashBackOfferQuery {OrderId = id});
            
            ViewBag.Order = order.Data;
            ViewBag.CashBackOffer = cashBackOffer.Data;

            return View(orderDetails.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatus([FromBody]OrderForUpdateStatusDto dto)
        {
            var result = await _mediator.Send(new UpdateOrderStatusCommand { Dto = dto });
            return StatusCode((int)result.Result.Code, result);
        }

        [HttpPost]
        [Route("Admin/Order/UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromForm] OrderStatus status)
        {
            var result = await _mediator.Send(new UpdateOrderStatusCommand { Dto = new OrderForUpdateStatusDto { OrderId = id, NewStatus = status } });
            // 4️⃣ Return success
            return Ok(new { message = "تم تحديث حالة الطلب بنجاح" });
        }


    }
}
