using Sense.Application.UseCases.Cateogry.Queries.GetAllContactUsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        private readonly IMediator _mediator;
        public ContactUsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetAllContactUsQuery { };
            var result = await _mediator.Send(query);
            var items = result.Data;
            ViewBag.ActiveMenu = "ContactUs";
            ViewData["title"] = "اتصل بنا";
            return View(items);
        }
    }
}
