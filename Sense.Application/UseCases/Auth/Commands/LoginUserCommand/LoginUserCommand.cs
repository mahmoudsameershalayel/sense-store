using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Auth.Commands.LoginUserCommand
{
    public class LoginUserCommand : IRequest<ResponseResult<TokenDto>>
    {
        public bool populateExp { get; set; }
        public UserForLoginDto? Dto { get; set; }
    }
}
