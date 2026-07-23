using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.UseCases.Banner.Queries.GetBannerByIdQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Service.Queries.GetServiceByIdQuery
{
    public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, ResponseResult<ServiceDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetServiceByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceDto>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.Service.GetServiceByIdAsync(request.ServiceId);
            if (entity is null)
                return ResponseResult<ServiceDto>.GetResult(ResultCodeStatus.NotFound, $"The Service with Id : {request.ServiceId} not exist in the database!!");
            var dto = _mapper.Map<ServiceDto>(entity);
            return ResponseResult<ServiceDto>.GetResult(ResultCodeStatus.Success, dto, "The data reterived successfully.");
        }
    }
}
