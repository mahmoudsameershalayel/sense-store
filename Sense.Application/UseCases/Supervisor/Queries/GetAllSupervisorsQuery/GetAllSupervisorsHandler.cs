using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.SupervisorDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Supervisor.Queries.GetAllSupervisorsQuery
{
    public class GetAllSupervisorsHandler : IRequestHandler<GetAllSupervisorsQuery, ResponseResult<IEnumerable<SupervisorDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllSupervisorsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<SupervisorDto>>> Handle(GetAllSupervisorsQuery request, CancellationToken cancellationToken)
        {
            var supervisors = await _repositoryManager.Supervisor.GetAllSupervisorsAsync();
            var dtos = _mapper.Map<List<SupervisorDto>>(supervisors);
            return ResponseResult<IEnumerable<SupervisorDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");
        }
    }
}
