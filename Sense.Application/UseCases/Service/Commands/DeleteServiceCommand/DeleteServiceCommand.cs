using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Service.Commands.DeleteServiceCommand
{
    public class DeleteServiceCommand : IRequest<ResponseResult<bool>>
    {
        public int ServiceId { get; set; }
    }
}
