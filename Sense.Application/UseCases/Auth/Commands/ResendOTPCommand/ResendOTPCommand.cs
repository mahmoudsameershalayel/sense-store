using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Auth.Commands.ResendOTPCommand
{
    public class ResendOTPCommand : IRequest<ResponseResult<PhoneVerificationTbl>>
    {
        public string? PhoneNumber { get; set; }
    }
}