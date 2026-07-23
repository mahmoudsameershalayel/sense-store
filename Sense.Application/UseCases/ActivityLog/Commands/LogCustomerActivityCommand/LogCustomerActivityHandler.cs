using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ActivityLog.Commands.LogSupervisorActivityCommand
{
    public class LogCustomerActivityHandler : IRequestHandler<LogCustomerActivityCommand, ResponseResult<bool>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public LogCustomerActivityHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(LogCustomerActivityCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"Customer Not Found!!");
            request.Dto.CustomerId = customer.Id;
            var log = _mapper.Map<CustomerActivityLog>(request.Dto);
            log.CreatedAt = DateTime.UtcNow;
            _repositoryManager.CustomerActivity.CreateCustomerActivityLog(log);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The activity log successfully");
        }
    }
}
