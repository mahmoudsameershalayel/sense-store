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

namespace Sense.Application.UseCases.ServiceProvider.Queries.GetAllServiceProvidersQuery
{
    public class GetAllServiceProvidersHandler : IRequestHandler<GetAllServiceProvidersQuery, ResponseResult<List<ServiceProviderDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllServiceProvidersHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<List<ServiceProviderDto>>> Handle(GetAllServiceProvidersQuery request, CancellationToken cancellationToken)
        {
            var serviceProviders = await _repositoryManager.ServiceProvider.GetAllServiceProvidersAsync();
            var activeServiceProviders = serviceProviders.Where(x => !x.IsDeleted && x.ApplicationUser != null && x.ApplicationUser.UserType == UserType.ServiceProvider && x.ApplicationUser.IsActive);
            var dtos = _mapper.Map<List<ServiceProviderDto>>(activeServiceProviders);
            return ResponseResult<List<ServiceProviderDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data retrieved successfully.");
        }
    }
}
