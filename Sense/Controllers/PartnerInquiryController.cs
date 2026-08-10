using Sense.Domain.DBEntities;
using Sense.Application.UseCases.PartnerInquiry.Commands.CreatePartnerInquiryCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Controllers
{
    public class PartnerInquiryController : Controller
    {
        private readonly IMediator _mediator;
        public PartnerInquiryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PartnerInquiryTbl model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            var result = await _mediator.Send(new CreatePartnerInquiryCommand { Inquiry = model });

            return Json(new { success = true, result = result });
        }
    }
}
