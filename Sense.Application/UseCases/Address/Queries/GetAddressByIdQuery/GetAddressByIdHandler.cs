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

namespace Sense.Application.UseCases.Address.Queries.GetAddressByIdQuery
{
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, ResponseResult<AddressDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAddressByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<AddressDto>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _repositoryManager.Address.GetAddressAsync(request.Id);

            if (address == null)
            {
                return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.NotFound, null, "Address not found");
            }

            var addressDto = _mapper.Map<AddressDto>(address);
            return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.Success, addressDto);
        }
    }
}
