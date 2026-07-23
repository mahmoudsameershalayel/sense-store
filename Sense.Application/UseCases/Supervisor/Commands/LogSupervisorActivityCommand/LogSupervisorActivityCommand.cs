using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Supervisor.Commands.LogSupervisorActivityCommand
{
    public class LogSupervisorActivityCommand : IRequest<ResponseResult<bool>>
    {
        public string CurrentUserId { get; set; }
        public SupervisorActivityLogForCreateDto? Dto { get; set; }
    }
}
