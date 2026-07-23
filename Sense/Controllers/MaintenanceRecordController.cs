using Sense.Application.UseCases.MaintenanceRecord.Queries.GetMaintenanceRecordQuery;
using Sense.Application.UseCases.Service.Queries.GetOtherServicesQuery;
using Sense.Application.UseCases.Service.Queries.GetServiceByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Controllers
{
    public class MaintenanceRecordController : Controller
    {
        private readonly IMediator _mediator;
        public MaintenanceRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _mediator.Send(new GetMaintenanceRecordQuery { MaintenanceRecordId = id });
            return View(result.Data);
        }
    }
}
