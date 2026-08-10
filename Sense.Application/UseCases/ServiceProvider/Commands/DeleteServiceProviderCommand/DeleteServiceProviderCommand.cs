using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceProvider.Commands.DeleteServiceProviderCommand
{
    public class DeleteServiceProviderCommand : IRequest<ResponseResult<bool>>
    {
        public string UserId { get; set; }
    }
}
