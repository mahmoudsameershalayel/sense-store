using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OfferCashbackDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Queries.GetActiveCashBackOfferQuery
{
    public class GetActiveCashBackOfferHandler : IRequestHandler<GetActiveCashBackOfferQuery, ResponseResult<CashbackOfferDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetActiveCashBackOfferHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CashbackOfferDto>> Handle(GetActiveCashBackOfferQuery request, CancellationToken cancellationToken)
        {
            var order = await _repositoryManager.Order.GetOrderById(request.OrderId);
            var items = await _repositoryManager.CashbackOffer.GetAllOffersAsync();
            var cashBackOffer = items.Where(x => x.IsActive == true && x.StartDate <= order.OrderDate && x.EndDate >= order.OrderDate).FirstOrDefault();
            var dtos = _mapper.Map<CashbackOfferDto>(cashBackOffer);
            return ResponseResult<CashbackOfferDto>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
