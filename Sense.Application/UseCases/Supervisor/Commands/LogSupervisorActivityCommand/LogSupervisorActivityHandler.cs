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

namespace Sense.Application.UseCases.Supervisor.Commands.LogSupervisorActivityCommand
{
    public class LogSupervisorActivityHandler : IRequestHandler<LogSupervisorActivityCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public LogSupervisorActivityHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(LogSupervisorActivityCommand request, CancellationToken cancellationToken)
        {
            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.CurrentUserId);
            if(supervisor is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"Supervisor Not Found!!");
            request.Dto.SupervisorId = supervisor.Id;
            var log = _mapper.Map<SupervisorActivityLog>(request.Dto);
            log.CreatedAt = DateTime.UtcNow;
            _repositoryManager.SupervisorActivity.CreateSupervisorActivityLog(log);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The activity log successfully");
        }
    }
}
