using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProviderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Provider.Commands.UpdateProviderCommand
{
    public class UpdateProviderCommand : IRequest<ResponseResult<ProviderDto>>
    {
        public string UserId { get; set; }
        public ProviderForUpdateDto Dto { get; set; }
    }
}
