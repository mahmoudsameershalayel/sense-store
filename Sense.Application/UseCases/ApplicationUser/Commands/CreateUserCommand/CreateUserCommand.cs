using Sense.Domain.Enums;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.ApplicationUser.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<ResponseResult<IdentityResult>>
    {
        public UserType UserType { get; set; }
        public int? BranchId { get; set; }
        public string? ProviderName { get; set; }
        public UserForRegisterDto? Dto { get; set; }
    }
}
