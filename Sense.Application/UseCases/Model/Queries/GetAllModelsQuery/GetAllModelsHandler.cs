using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ModelDTOs;
using AutoMapper;
using MediatR;

namespace Sense.Application.UseCases.Model.Queries.GetAllModelsQuery
{
    public class GetAllModelsHandler : IRequestHandler<GetAllModelsQuery, ResponseResult<IEnumerable<ModelDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllModelsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ModelDto>>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.Model.GetAllBrandTypesAsync();
            var dtos = _mapper.Map<List<ModelDto>>(items);
            return ResponseResult<IEnumerable<ModelDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
