using Sense.Domain.Enums;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.FreeMaintenanceOffer.Commands.ActivateFreeMaintenanceOfferCommand;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetAllFreeMaintenanceOfferQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sense.Controllers
{
    [Route("FreeMaintenanceOffer")]
    public class FreeMaintenanceOfferController : Controller
    {
        private readonly IMediator _mediator;
        public FreeMaintenanceOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllFreeMaintenanceOfferQuery { });
            var items = result.Data;
            return View(items);
        }

        [HttpPut("Activate/{id}")]
        public async Task<IActionResult> Activate(int id)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new ActivateFreeMaintenanceOfferCommand { Dto = new ActivateFreeMaintenanceOfferDto { CurrentUserId = currentUserId , OfferId = id} });
            if(result.Result.Code == ResultCodeStatus.Success)
                return Json(new { success = true });

            return Json(new { success = false });
        }

    }
}
