using Sense.Application;
using Sense.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteAddressHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repositoryManager.Address.GetAddressAsync(request.Id);
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if(customer is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "Customer not found");


            if (address is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, "Address not found");

            if (address.CustomerId != customer.Id)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Forbiden, false, "you are not authorized to delete this address");


            address.IsDeleted = true;
            _repositoryManager.Address.UpdateAddress(address);
            await _repositoryManager.SaveAsync();

            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"Address with Id {address.Id} deleted successfully");
        }
    }
}
