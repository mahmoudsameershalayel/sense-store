using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ModelDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Model.Queries.GetModelsByBrandIdQuery
{
    public class GetModelsByBrandIdHandler : IRequestHandler<GetModelsByBrandIdQuery, ResponseResult<IEnumerable<ModelDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetModelsByBrandIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ModelDto>>> Handle(GetModelsByBrandIdQuery request, CancellationToken cancellationToken)
        {

            var allitems = await _repositoryManager.Model.GetAllBrandTypesAsync();
            var items = allitems.Where(x => x.BrandId == request.BrandId).ToList();
            var dtos = _mapper.Map<List<ModelDto>>(items);
            return ResponseResult<IEnumerable<ModelDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
