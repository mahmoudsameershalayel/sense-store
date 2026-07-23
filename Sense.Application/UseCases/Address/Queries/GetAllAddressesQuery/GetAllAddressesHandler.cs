using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AddressDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Address.Queries.GetAllAddressesQuery
{
    public class GetAllAddressesHandler : IRequestHandler<GetAllAddressesQuery, ResponseResult<IEnumerable<AddressDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllAddressesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<AddressDto>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _repositoryManager.Address.GetAllAddressesAsync();
            var addressDtos = _mapper.Map<IEnumerable<AddressDto>>(addresses);

            return ResponseResult<IEnumerable<AddressDto>>.GetResult(ResultCodeStatus.Success, addressDtos);
        }
    }
}
