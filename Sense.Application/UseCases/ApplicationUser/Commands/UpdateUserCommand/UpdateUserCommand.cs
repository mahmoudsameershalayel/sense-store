using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<ResponseResult<UserDto>>
    {
        public string UserId { get; set; }
        public ApplicationUserForUpdateDto? Dto { get; set; }
    }
}
