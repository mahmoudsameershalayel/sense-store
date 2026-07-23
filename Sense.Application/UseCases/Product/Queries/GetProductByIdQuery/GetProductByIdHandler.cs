using Sense.Application;
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

namespace Sense.Application.UseCases.Product.Queries.GetProductByIdQuery
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ResponseResult<ProductDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetProductByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Product.GetProductByIdAsync(request.ProductId);
            if (entity is null)
                return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.NotFound, $"The Product with Id : {request.ProductId} not exist in the database!!");
            var dto = _mapper.Map<ProductDto>(entity);
            return ResponseResult<ProductDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
