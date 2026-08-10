using Sense.Application;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceProviderDTOs;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceProvider.Queries.GetServiceProviderByUserIdQuery
{
    public class GetServiceProviderByUserIdHandler : IRequestHandler<GetServiceProviderByUserIdQuery, ResponseResult<ServiceProviderDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetServiceProviderByUserIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<ServiceProviderDto>> Handle(GetServiceProviderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var serviceProvider = await _repositoryManager.ServiceProvider.GetServiceProviderByApplicationUserId(request.CurrentUserId);
            if (serviceProvider is null)
                return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.NotFound, $"مزود الخدمة غير موجود!");

            var dto = _mapper.Map<ServiceProviderDto>(serviceProvider);
            return ResponseResult<ServiceProviderDto>.GetResult(ResultCodeStatus.Success, dto, "The data retrieved successfully.");
        }
    }
}
