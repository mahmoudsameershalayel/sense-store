using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using AutoMapper;
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
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, ResponseResult<AddressDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateAddressHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<AddressDto>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if(customer is null)
                return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.NotFound, $"The User Not Found!!");

            var address = _mapper.Map<AddressTbl>(request.Dto);
            address.CustomerId = customer.Id;
            _repositoryManager.Address.CreateAddress(address);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var addressDto = _mapper.Map<AddressDto>(address);
            return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.Created, addressDto, $"Address created with Id {address.Id}");
        }
    }
}
