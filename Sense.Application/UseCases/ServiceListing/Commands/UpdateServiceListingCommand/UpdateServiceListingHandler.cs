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

namespace Sense.Application.UseCases.ServiceListing.Commands.UpdateServiceListingCommand
{
    public class UpdateServiceListingHandler : IRequestHandler<UpdateServiceListingCommand, ResponseResult<ServiceListingDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateServiceListingHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceListingDto>> Handle(UpdateServiceListingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.ServiceListing.GetServiceListingByIdAsync(request.ServiceListingId);
            if (entity is null)
                return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.NotFound, $"The Service Listing with Id : {request.ServiceListingId} not exist in the database!!");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.ServiceListing.UpdateServiceListing(entity);

            await _repositoryManager.SaveAsync();
            var dto = _mapper.Map<ServiceListingDto>(entity);

            return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.Success, dto, $"The Service Listing with Id : {request.ServiceListingId} updated successfully.");
        }
    }
}
