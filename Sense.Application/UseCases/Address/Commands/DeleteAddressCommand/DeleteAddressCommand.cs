using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressCommand : IRequest<ResponseResult<bool>>
    {
        public required string CurrentUserId { get; set; }

        public int Id { get; set; }
    }
}