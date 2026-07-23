using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserAccountStatusCommand
{
    public class UpdateUserAccountStatusCommand : IRequest<ResponseResult<bool>>
    {
        public string? UserId { get; set; }
    }
}
