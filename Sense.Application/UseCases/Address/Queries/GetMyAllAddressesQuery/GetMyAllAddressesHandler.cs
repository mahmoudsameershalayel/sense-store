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

namespace Sense.Application.UseCases.Address.Queries.GetMyAllAddressesQuery
{
    public class GetMyAllAddressesHandler : IRequestHandler<GetMyAllAddressesQuery, ResponseResult<IEnumerable<AddressDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetMyAllAddressesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<AddressDto>>> Handle(GetMyAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if(customer is null)
                return ResponseResult<IEnumerable<AddressDto>>.GetResult(ResultCodeStatus.NotFound, "The Customer Not Found!!");

            var addresses = await _repositoryManager.Address.GetAddressesByCustomerId(customer.Id);
            var addressDtos = _mapper.Map<IEnumerable<AddressDto>>(addresses);

            return ResponseResult<IEnumerable<AddressDto>>.GetResult(ResultCodeStatus.Success, addressDtos , "The addresses reterived successfully");
        }
    }
}
