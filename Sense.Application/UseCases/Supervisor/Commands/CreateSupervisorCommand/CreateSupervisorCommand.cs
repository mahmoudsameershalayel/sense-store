using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Supervisor.Commands.CreateSupervisorCommand
{
    public class CreateSupervisorCommand : IRequest<ResponseResult<IdentityResult>>
    {
        public UserForRegisterDto? Dto { get; set; }
    }
}
