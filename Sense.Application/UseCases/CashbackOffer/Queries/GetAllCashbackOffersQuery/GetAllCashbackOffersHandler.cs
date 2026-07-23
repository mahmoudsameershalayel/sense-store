using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery
{
    public class GetAllCashbackOffersHandler : IRequestHandler<GetAllCashbackOffersQuery, ResponseResult<IEnumerable<CashbackOfferDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllCashbackOffersHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<CashbackOfferDto>>> Handle(GetAllCashbackOffersQuery request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.CashbackOffer.GetAllOffersAsync();
            var dtos = _mapper.Map<List<CashbackOfferDto>>(items);
            return ResponseResult<IEnumerable<CashbackOfferDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
