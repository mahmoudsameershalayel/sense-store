using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CustomerDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ActivityLog.Commands.LogSupervisorActivityCommand
{
    public class LogCustomerActivityCommand : IRequest<ResponseResult<bool>>
    {
        public string CurrentUserId { get; set; }
        public CustomerActivityLogForCreateDto? Dto { get; set; }
    }
}
