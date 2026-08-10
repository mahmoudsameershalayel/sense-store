using Sense.Application.UseCases.PartnerInquiry.Queries.GetAllPartnerInquiriesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class PartnerInquiryController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public PartnerInquiryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetAllPartnerInquiriesQuery { };
            var result = await _mediator.Send(query);
            var items = result.Data;
            ViewBag.ActiveMenu = "PartnerInquiry";
            ViewData["title"] = "طلبات تقديم خدمة أو منتج";
            return View(items);
        }
    }
}
