using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.TechSupport.Commands.DisableTechSupportCommand
{
    public class DisableTechSupportCommand : IRequest<ResponseResult<bool>>
    {
        public int TechSupportId { get; set; }
    }
}
