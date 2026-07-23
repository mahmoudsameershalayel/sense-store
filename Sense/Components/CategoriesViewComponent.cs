using Sense.Domain;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public CategoriesViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());

            ViewBag.Categories = categories.Data;
            return View();
        }
    }
}
