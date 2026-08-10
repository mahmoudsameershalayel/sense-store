using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceListingDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Queries.GetServiceListingByIdQuery
{
    public class GetServiceListingByIdHandler : IRequestHandler<GetServiceListingByIdQuery, ResponseResult<ServiceListingDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetServiceListingByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceListingDto>> Handle(GetServiceListingByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.ServiceListing.GetServiceListingByIdAsync(request.ServiceListingId);
            if (entity is null)
                return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.NotFound, $"The Service Listing with Id : {request.ServiceListingId} not exist in the database!!");
            var dto = _mapper.Map<ServiceListingDto>(entity);
            return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
