using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Service.Queries.GetOtherServicesQuery
{
    public class GetOtherServicesHandler : IRequestHandler<GetOtherServicesQuery, ResponseResult<IEnumerable<ServiceDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetOtherServicesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<ServiceDto>>> Handle(GetOtherServicesQuery request, CancellationToken cancellationToken)
        {

            var services = await _repositoryManager.Service.GetAllServicesAsync();
            var otherServices = services.Where(x => x.Id != request.ServiceId).ToList();
            var dtos = _mapper.Map<List<ServiceDto>>(otherServices);
            return ResponseResult<IEnumerable<ServiceDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
