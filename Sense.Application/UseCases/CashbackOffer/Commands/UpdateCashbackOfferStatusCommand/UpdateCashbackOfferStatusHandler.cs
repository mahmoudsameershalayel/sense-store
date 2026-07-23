using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserAccountStatusCommand;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Commands.UpdateCashbackOfferStatusCommand
{
    public class UpdateCashbackOfferStatusHandler : IRequestHandler<UpdateCashbackOfferStatusCommand, ResponseResult<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateCashbackOfferStatusHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<bool>> Handle(UpdateCashbackOfferStatusCommand request, CancellationToken cancellationToken)
        {
            var offer = await _repositoryManager.CashbackOffer.GetOfferByIdAsync(request.OfferId);
            if (offer is null)
                return ResponseResult<bool>.GetResult(ResultCodeStatus.NotFound, false, $"The offer with id : {request.OfferId} Not Found!!");

            offer.IsActive = !offer.IsActive;

            _repositoryManager.CashbackOffer.UpdateOffer(offer);
            var result = await _repositoryManager.SaveAsync();
            if (result != 0)
            {
                return ResponseResult<bool>.GetResult(ResultCodeStatus.Success, true, $"The offer with id : {offer.Id} Updated successfully");
            }
            return ResponseResult<bool>.GetResult(ResultCodeStatus.BadRequest, false, $"The Operation Failed!!");
        }


    }
}
