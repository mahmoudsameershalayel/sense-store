using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CashbackOfferUsageDTOs;
using Sense.Application.DTOs.FreeMaintenanceEligibilityDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using Sense.Application.UseCases.OfferCashback.Commands.CreateCashbackOfferCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Commands.UseCashbackOfferCommand
{
    public class UseCashbackOfferHandler : IRequestHandler<UseCashbackOfferCommand, ResponseResult<CashbackOfferUsageDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UseCashbackOfferHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CashbackOfferUsageDto>> Handle(UseCashbackOfferCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.CurrentUserId);
            if (customer is null)
                return ResponseResult<CashbackOfferUsageDto>.GetResult(ResultCodeStatus.NotFound, "The User Not Found!!"); var cashbackOffer = await _repositoryManager.CashbackOffer.GetOfferByIdAsync(request.Dto.CashbackOfferId);
           
            if (cashbackOffer is null)
                return ResponseResult<CashbackOfferUsageDto>.GetResult(ResultCodeStatus.NotFound, "The Cashback Offer Not Found!!");

             if(!cashbackOffer.IsActive || DateTime.UtcNow < cashbackOffer.StartDate  || DateTime.UtcNow > cashbackOffer.EndDate)
                return ResponseResult<CashbackOfferUsageDto>.GetResult(ResultCodeStatus.BadRequest, "The Cashback Offer Not Active!!");

            var entity = _mapper.Map<CashbackOfferUsageTbl>(request.Dto);
            _repositoryManager.CashbackOfferUsage.CreateOfferUsage(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<CashbackOfferUsageDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<CashbackOfferUsageDto>(entity);
            return ResponseResult<CashbackOfferUsageDto>.GetResult(ResultCodeStatus.Created, dto, $"The cashback with Id : {entity.Id} used successfully");
        }
    }
}
