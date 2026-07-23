using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BannerDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using Sense.Application.UseCases.Banner.Queries.GetAllBannersQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Service.Queries.GetAllServicesQuery
{
    public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, ResponseResult<IEnumerable<ServiceDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllServicesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ServiceDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.Service.GetAllServicesAsync();
            var dtos = _mapper.Map<List<ServiceDto>>(items);
            return ResponseResult<IEnumerable<ServiceDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
