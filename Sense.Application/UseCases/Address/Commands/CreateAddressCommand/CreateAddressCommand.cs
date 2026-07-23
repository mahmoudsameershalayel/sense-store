using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;

namespace Sense.Application.UseCases.Address.Commands.CreateAddressCommand
{
    public class CreateAddressCommand : IRequest<ResponseResult<AddressDto>>
    {
        public string CurrentUserId { get; set; }
        public AddressForCreateDto Dto { get; set; }
    }
}
