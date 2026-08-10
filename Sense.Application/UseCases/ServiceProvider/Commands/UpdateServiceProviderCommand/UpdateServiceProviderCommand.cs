using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceProviderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceProvider.Commands.UpdateServiceProviderCommand
{
    public class UpdateServiceProviderCommand : IRequest<ResponseResult<ServiceProviderDto>>
    {
        public string UserId { get; set; }
        public ServiceProviderForUpdateDto Dto { get; set; }
    }
}
