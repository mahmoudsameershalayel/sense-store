using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.UseCases.Cateogry.Queries.GetAllCategoriesQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, ResponseResult<IEnumerable<BrandDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllBrandsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<BrandDto>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.Brand.GetAllBrandsAsync();
            var dtos = _mapper.Map<List<BrandDto>>(items);
            return ResponseResult<IEnumerable<BrandDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
