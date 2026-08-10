using Sense.Application;
using Sense.Domain.DBEntities;
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

namespace Sense.Application.UseCases.ServiceListing.Commands.CreateServiceListingCommand
{
    public class CreateServiceListingHandler : IRequestHandler<CreateServiceListingCommand, ResponseResult<ServiceListingDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateServiceListingHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceListingDto>> Handle(CreateServiceListingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ServiceListingTbl>(request.Dto);
            entity.Status = request.InitialStatus;
            _repositoryManager.ServiceListing.CreateServiceListing(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<ServiceListingDto>(entity);
            return ResponseResult<ServiceListingDto>.GetResult(ResultCodeStatus.Created, dto, $"The Service Listing with Id : {entity.Id} created successfully");
        }
    }
}
