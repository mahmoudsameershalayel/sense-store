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

namespace Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, ResponseResult<IEnumerable<CategoryDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllCategoriesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.Category.GetAllCategoriesAsync();
            var dtos = _mapper.Map<List<CategoryDto>>(items);
            return ResponseResult<IEnumerable<CategoryDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
