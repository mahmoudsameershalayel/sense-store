using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Address.Queries.GetAddressByIdQuery
{
    public class GetAddressByIdQuery : IRequest<ResponseResult<AddressDto>>
    {
        public int Id { get; set; }
    }
}
