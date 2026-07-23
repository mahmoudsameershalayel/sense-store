using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressCommand : IRequest<ResponseResult<AddressDto>>
    {
        public required string CurrentUserId { get; set; }
        public AddressForUpdateDto Dto { get; set; }
    }
}
