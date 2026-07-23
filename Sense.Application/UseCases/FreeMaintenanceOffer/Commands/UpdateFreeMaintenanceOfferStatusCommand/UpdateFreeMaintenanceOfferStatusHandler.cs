using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using System;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Commands.UpdateFreeMaintenanceOfferStatusCommand
{
    public class UpdateFreeMaintenanceOfferStatusHandler : IRequestHandler<UpdateFreeMaintenanceOfferStatusCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public UpdateFreeMaintenanceOfferStatusHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(UpdateFreeMaintenanceOfferStatusCommand request, CancellationToken cancellationToken)
        {
            var offer = await _repositoryManager.FreeMaintenanceOffer.GetFreeMaintenanceOfferByIdAsync(request.OfferId);
            if (offer is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The offer with id : {request.OfferId} Not Found!!");

            offer.IsActive = !offer.IsActive;

            _repositoryManager.FreeMaintenanceOffer.UpdateFreeMaintenanceOffer(offer);
            var result = await _repositoryManager.SaveAsync();
            if (result != 0)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The offer with id : {offer.Id} Updated successfully");

            return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"The Operation Failed!!");
        }


    }
}
