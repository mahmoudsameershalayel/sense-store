using Sense.Application;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProviderDTOs;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Provider.Queries.GetAllProvidersQuery
{
    public class GetAllProvidersHandler : IRequestHandler<GetAllProvidersQuery, ResponseResult<List<ProviderDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllProvidersHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<List<ProviderDto>>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
        {
            var providers = await _repositoryManager.Provider.GetAllProvidersAsync();
            var activeProviders = providers.Where(x => !x.IsDeleted && x.ApplicationUser != null && x.ApplicationUser.UserType == UserType.Provider && x.ApplicationUser.IsActive);
            var dtos = _mapper.Map<List<ProviderDto>>(activeProviders);
            return ResponseResult<List<ProviderDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data retrieved successfully.");
        }
    }
}
