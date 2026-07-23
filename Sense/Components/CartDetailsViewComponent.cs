using Sense.Domain;
using Sense.Application.DTOs.ProductDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SenseWeb.Components
{
    public class CartDetailsViewComponent : ViewComponent
    {
        private readonly SenseDbContext _context;
        private readonly IMapper _mapper;

        public CartDetailsViewComponent(SenseDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var product = _context.ProductTbls.Where(x => x.Id == productId).FirstOrDefault();
            var dto = _mapper.Map<ProductDto>(product);
            return View(dto);
        }
    }
}
