using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using Sense.Application.DTOs.SupervisorDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Commands.UpdateSupervisorCommand
{
    public class UpdateSupervisorCommand : IRequest<ResponseResult<UserDto>>
    {
        public SupervisorForUpdateDto? Dto { get; set; }
    }
}
