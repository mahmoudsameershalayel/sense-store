using MediatR;
using Sense.Application;
using Sense.Application.Abstractions;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.CashbackOffer.Commands.DeleteCashbackOfferCommand;
using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Commands.DeleteFreeMaintenanceOfferCommand
{
    public class DeleteFreeMaintenanceOfferHandler : IRequestHandler<DeleteFreeMaintenanceOfferCommand, ResponseResult<bool>>
    {
        private readonly IImageServices _imageService;
        private readonly IRepositoryManager _repositoryManager;
        public DeleteFreeMaintenanceOfferHandler(IRepositoryManager repositoryManager, IImageServices imageServices)
        {
            _imageService = imageServices;
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteFreeMaintenanceOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.FreeMaintenanceOffer.GetFreeMaintenanceOfferByIdAsync(request.FreeMaintenanceOfferId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Free Maintenance Offer with Id : {request.FreeMaintenanceOfferId} not exist in the database!!");

            if (!string.IsNullOrEmpty(entity.ImageURL))
                await _imageService.DeleteImage(entity.ImageURL);
              entity.IsDeleted = true;
            _repositoryManager.FreeMaintenanceOffer.UpdateFreeMaintenanceOffer(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Free Maintenance Offer with Id : {request.FreeMaintenanceOfferId} deleted successfully");
        }
    }
}
