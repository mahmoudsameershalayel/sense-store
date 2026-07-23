using Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery;
using Sense.Application.UseCases.Branch.Queries.GetAllBranchesQuery;
using Sense.Application.UseCases.Branch.Queries.GetBranchByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Controllers
{
	public class BranchController : Controller
	{
		private readonly IMediator _mediator;
		public BranchController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _mediator.Send(new GetAllBranchesQuery { });
			var items = result.Data;
			return View(items);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var result = await _mediator.Send(new GetBranchByIdQuery {BranchId = id });
			var item = result.Data;
			return View(item);
		}
	}
}
