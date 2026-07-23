using Sense.Domain.DBEntities;
using Sense.Application.DTOs.AddressDTOs;
using Sense.Application.UseCases.Address.Commands.CreateAddressCommand;
using Sense.Application.UseCases.Cateogry.Commands.CreateContactUsCommand;
using Sense.Areas.Admin.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sense.Controllers
{
    public class ContactUsController : Controller 
    {
        private readonly IMediator _mediator;
        public ContactUsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContactFormTbl model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false });

            var result = await _mediator.Send(new CreateContactUsCommand { Contact = model });

            return Json(new { success = true , result = result } );

        }
    }
}
