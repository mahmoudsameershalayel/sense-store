using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.UseCases.Banner.Commands.CreateBannerCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Service.Commands.CreateServiceCommand
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, ResponseResult<ServiceDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateServiceHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceDto>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ServiceTbl>(request.Dto);
            _repositoryManager.Service.CreateService(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<ServiceDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<ServiceDto>(entity);
            return ResponseResult<ServiceDto>.GetResult(ResultCodeStatus.Created, dto, $"The Service with Id : {entity.Id} created successfully");
        }
    }
}

