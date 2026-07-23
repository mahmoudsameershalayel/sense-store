using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Address.Queries.GetAllAddressesQuery
{
    public class GetAllAddressesQuery : IRequest<ResponseResult<IEnumerable<AddressDto>>>
    {
    }
}
