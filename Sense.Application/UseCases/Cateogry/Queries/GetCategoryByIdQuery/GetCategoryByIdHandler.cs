using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Cateogry.Queries.GetCategoryByIdQuery
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, ResponseResult<CategoryDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetCategoryByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Category.GetCategoryByIdAsync(request.CategoryId);
            if (entity is null)
                return ResponseResult<CategoryDto>.GetResult(ResultCodeStatus.NotFound, $"The Category with Id : {request.CategoryId} not exist in the database!!");
            var dto = _mapper.Map<CategoryDto>(entity);
            return ResponseResult<CategoryDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
