using Sense.Domain;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sense.Performance;

namespace Sense.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly StorefrontDataCache _storefrontData;

        public CategoriesViewComponent(StorefrontDataCache storefrontData)
        {
            _storefrontData = storefrontData;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _storefrontData.GetCategoriesAsync();

            ViewBag.Categories = categories;
            return View();
        }
    }
}
