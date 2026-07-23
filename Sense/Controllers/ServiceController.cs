using Sense.Application.RequestFeatures;
using Sense.Application.UseCases.Product.Queries.GetAllProductsQuery;
using Sense.Application.UseCases.Service.Queries.GetAllServicesQuery;
using Sense.Application.UseCases.Service.Queries.GetOtherServicesQuery;
using Sense.Application.UseCases.Service.Queries.GetServiceByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var serviecs = await _mediator.Send(new GetAllServicesQuery { });
            return View(serviecs.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var service = await _mediator.Send(new GetServiceByIdQuery { ServiceId = id});
            var otherServices = await _mediator.Send(new GetOtherServicesQuery {ServiceId = id });
            ViewBag.OtherServices = otherServices.Data;
            return View(service.Data);
        }
    }
}
