using Sense.Application;
using Sense.Domain.DBEntities;
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

namespace Sense.Application.UseCases.Supervisor.Queries.GetAllSupervisorsByBranchIdQuery
{
    public class GetAllSupervisorsByBranchIdHandler : IRequestHandler<GetAllSupervisorsByBranchIdQuery, ResponseResult<IEnumerable<SupervisorDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllSupervisorsByBranchIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<SupervisorDto>>> Handle(GetAllSupervisorsByBranchIdQuery request, CancellationToken cancellationToken)
        {

            var supervisors = await _repositoryManager.Supervisor.GetAllSupervisorsAsync();
            var supervisorsByBranch = supervisors.Where(x => x.BranchId == request.BranchId).ToList();
            var dtos = _mapper.Map<List<SupervisorDto>>(supervisorsByBranch);
            return ResponseResult<IEnumerable<SupervisorDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
