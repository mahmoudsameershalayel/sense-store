using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Auth.Commands.LoginUserWebCommand
{
    public class LoginUserWebCommand : IRequest<ResponseResult<UserDto>>
    {
        public UserForLoginDto? Dto { get; set; }
    }
}