using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Queries.GetAllSupervisorsQuery
{
    public class GetAllSupervisorsHandler : IRequestHandler<GetAllSupervisorsQuery, ResponseResult<IEnumerable<SupervisorTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllSupervisorsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<SupervisorTbl>>> Handle(GetAllSupervisorsQuery request, CancellationToken cancellationToken)
        {
            var supervisors = await _repositoryManager.Supervisor.GetAllSupervisorsAsync();

            if (!string.IsNullOrEmpty(request.Name))
                supervisors = supervisors.Where(i => i.ApplicationUser.FirstName.Contains(request.Name) || i.ApplicationUser.LastName.Contains(request.Name) || i.ApplicationUser.UserName.Contains(request.Name)).ToList();

            return ResponseResult<IEnumerable<SupervisorTbl>>.GetResult(ResultCodeStatus.Success, supervisors, "Users retrieved successfully");
        }
    }

}
