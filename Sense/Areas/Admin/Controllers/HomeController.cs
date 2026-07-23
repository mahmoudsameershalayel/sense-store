using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.UseCases.ApplicationUser.Queries.GetAllUsersQuery;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsForStatisticsQuery;
using Sense.Application.UseCases.Appointment.Queries.GetAllAppointmentsQuery;
using Sense.Application.UseCases.Order.Queries.GetAllOrdersForStatisticsQuery;
using Sense.Application.UseCases.Order.Queries.GetAllOrdersQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var allAppointments = await _mediator.Send(new GetAllAppointmentsForStatisticsQuery { });
			var allCustomers = await _mediator.Send(new GetAllUsersQuery { UserType = UserType.Customer });
			var allProviders = await _mediator.Send(new GetAllUsersQuery { UserType = UserType.Provider });
			var allOrders = await _mediator.Send(new GetAllOrdersForStatisticsQuery { });

			ViewBag.TotalBookings = allAppointments.Data?.Count();
            ViewBag.PendingBookings = allAppointments.Data?.Where(x => x.Status == "Pending").Count();
            ViewBag.AcceptedBookings = allAppointments.Data?.Where(x => x.Status == "Scheduled").Count();
            ViewBag.RejectedBookings = allAppointments.Data?.Where(x => x.Status == "Rejected").Count();
            ViewBag.TotalProviders = allProviders.Data?.Count();
            ViewBag.TotalCustomers = allCustomers.Data?.Count();
            ViewBag.TotalOrders = allOrders.Data?.Count();
            ViewBag.TotalOrdersProfit = allOrders.Data?.Select(x => x.TotalOrderNet).Sum();

            return View();
        }
    }
}
