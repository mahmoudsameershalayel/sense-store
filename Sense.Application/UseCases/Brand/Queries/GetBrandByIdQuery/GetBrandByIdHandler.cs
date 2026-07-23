using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Brand.Queries.GetBrandByIdQuery
{
    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, ResponseResult<BrandDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetBrandByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<BrandDto>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Brand.GetBrandByIdAsync(request.BrandId);
            if (entity is null)
                return ResponseResult<BrandDto>.GetResult(ResultCodeStatus.NotFound, $"The Brand with Id : {request.BrandId} not exist in the database!!");
            var dto = _mapper.Map<BrandDto>(entity);
            return ResponseResult<BrandDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
