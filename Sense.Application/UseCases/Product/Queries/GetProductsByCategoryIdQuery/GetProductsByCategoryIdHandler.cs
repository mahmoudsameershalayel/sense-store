using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Queries.GetProductsByCategoryIdQuery
{
    public class GetProductsByCategoryIdHandler : IRequestHandler<GetProductsByCategoryIdQuery, ResponseResult<IEnumerable<ProductDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetProductsByCategoryIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ProductDto>>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repositoryManager.Product.GetAllProductsAsync(new ProductParameters { Status = ProductStatus.Published });
            var products = entities.Where(x => x.CategoryId == request.CategoryId).ToList();          
            var dtos = _mapper.Map<List<ProductDto>>(products);
            return ResponseResult<IEnumerable<ProductDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");
        }
    }
}
