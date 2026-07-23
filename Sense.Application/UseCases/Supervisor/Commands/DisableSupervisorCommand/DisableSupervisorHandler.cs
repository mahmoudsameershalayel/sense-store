using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Supervisor.Commands.DisableSupervisorCommand
{
    public class DisableSupervisorHandler : IRequestHandler<DisableSupervisorCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public DisableSupervisorHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
        }
     

        public async Task<ResponseResult<bool>> Handle(DisableSupervisorCommand request, CancellationToken cancellationToken)
        {
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByIdAsync(request.SupervisorId);
            if(supervisor is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound,false ,  $"The Supervisor Not Found!!");

            supervisor.IsActive = false;
            _repositoryManager.Supervisor.UpdateSupervisor(supervisor);
            await _repositoryManager.SaveAsync();

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Operation Failed!!");
        }


    }
}