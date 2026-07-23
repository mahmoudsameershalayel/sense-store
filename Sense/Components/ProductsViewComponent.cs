using Sense.Domain;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ProductDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sense.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly SenseDbContext _context;
        private readonly IMapper _mapper;

        public ProductsViewComponent(SenseDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var products = _context.ProductTbls
                .Where(x => x.IsDeleted == false && x.Status == ProductStatus.Published)
                .Include(x => x.Category).Include(x => x.Brand).Include(x => x.Provider)
                .ToList();
            var dtos = _mapper.Map<List<ProductDto>>(products); 
  
            return View(dtos);
        }
    }
}
