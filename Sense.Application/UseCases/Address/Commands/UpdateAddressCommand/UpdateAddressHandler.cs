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

namespace Sense.Application.UseCases.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, ResponseResult<AddressDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateAddressHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<AddressDto>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {

            var address = await _repositoryManager.Address.GetAddressAsync(request.Dto.Id);
            if (address is null)
                return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.NotFound, null, "Address not found");
           
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.NotFound, $"The User Not Found!!");

            if (address.CustomerId != customer.Id)
                return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.Forbiden, $"You can not update this address!!");


            _mapper.Map(request.Dto, address); 
            address.ModifiedAt = DateTime.UtcNow;
            _repositoryManager.Address.UpdateAddress(address);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var addressDto = _mapper.Map<AddressDto>(address);
            return ResponseResult<AddressDto>.GetResult(ResultCodeStatus.Success, addressDto, $"Address with Id {address.Id} updated successfully");
        }
    }
}
