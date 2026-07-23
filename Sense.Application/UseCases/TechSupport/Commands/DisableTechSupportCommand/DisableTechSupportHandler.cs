using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Supervisor.Commands.DisableSupervisorCommand;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.TechSupport.Commands.DisableTechSupportCommand
{
    public class DisableTechSupportHandler : IRequestHandler<DisableTechSupportCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public DisableTechSupportHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
        }


        public async Task<ResponseResult<bool>> Handle(DisableTechSupportCommand request, CancellationToken cancellationToken)
        {
            var techSupport = await _repositoryManager.TechSupport.GetTechSupportByIdAsync(request.TechSupportId);
            if (techSupport is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The TechSupport Not Found!!");

            techSupport.IsActive = false;
            _repositoryManager.TechSupport.UpdateTechSupport(techSupport);
            await _repositoryManager.SaveAsync();

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Operation Failed!!");
        }


    }
}