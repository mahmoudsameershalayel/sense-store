using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Brand.Commands.DeleteBrandCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Commands.DeleteCashbackOfferCommand
{
    public class DeleteCashbackOfferHandler : IRequestHandler<DeleteCashbackOfferCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IImageServices _imageServices;
        public DeleteCashbackOfferHandler(IRepositoryManager repositoryManager, IImageServices imageServices)
        {
            _repositoryManager = repositoryManager;
            _imageServices = imageServices;
        }

        public async Task<ResponseResult<bool>> Handle(DeleteCashbackOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.CashbackOffer.GetOfferByIdAsync(request.CashbackOfferId);
            if (entity is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The Cashback Offer with Id : {request.CashbackOfferId} not exist in the database!!");

            if (!string.IsNullOrEmpty(entity.ImageURL))
                await _imageServices.DeleteImage(entity.ImageURL);

            entity.IsDeleted = true;
            _repositoryManager.CashbackOffer.UpdateOffer(entity);
            await _repositoryManager.SaveAsync();
            return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The Cashback Offer with Id : {request.CashbackOfferId} deleted successfully");
        }
    }
}
