using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Auth.Commands.RefreshTokenCommand
{
    public class RefreshTokenCommand : IRequest<ResponseResult<TokenDto>>
    {
        public TokenDto? Dto { get; set; }
    }
}
