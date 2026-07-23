using Sense.Application.UseCases.Model.Queries.GetModelsByBrandIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Controllers
{
    public class ModelController : Controller
    {
        private readonly IMediator _mediator;

        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("Model/GetModelsByBrandId/{brandId}")]
        public async Task<IActionResult> GetModelsByBrandId(int brandId)
        {
            var query = new GetModelsByBrandIdQuery { BrandId = brandId };
            var result = await _mediator.Send(query);
            return StatusCode((int)result.Result.Code, result.Data);
        }

    }
}
