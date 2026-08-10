using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceListingDTOs;
using AutoMapper;
using MediatR;

namespace Sense.Application.UseCases.ServiceListing.Queries.GetAllServiceListingsQuery
{
    public class GetAllServiceListingsHandler : IRequestHandler<GetAllServiceListingsQuery, ResponseResult<IEnumerable<ServiceListingDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllServiceListingsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ServiceListingDto>>> Handle(GetAllServiceListingsQuery request, CancellationToken cancellationToken)
        {

            var itemsWithMetaData = await _repositoryManager.ServiceListing.GetAllServiceListingsAsync(request.ServiceListingParameters);
            var dtos = _mapper.Map<List<ServiceListingDto>>(itemsWithMetaData);
            return ResponseResult<IEnumerable<ServiceListingDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
