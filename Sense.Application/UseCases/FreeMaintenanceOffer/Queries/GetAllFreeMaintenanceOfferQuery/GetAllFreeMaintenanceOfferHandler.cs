using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetAllFreeMaintenanceOfferQuery
{
    public class GetAllFreeMaintenanceOfferHandler : IRequestHandler<GetAllFreeMaintenanceOfferQuery, ResponseResult<IEnumerable<FreeMaintenanceOfferDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllFreeMaintenanceOfferHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<FreeMaintenanceOfferDto>>> Handle(GetAllFreeMaintenanceOfferQuery request, CancellationToken cancellationToken)
        {

            var items = await _repositoryManager.FreeMaintenanceOffer.GetAllFreeMaintenanceOffersAsync();
            var dtos = _mapper.Map<List<FreeMaintenanceOfferDto>>(items);
            return ResponseResult<IEnumerable<FreeMaintenanceOfferDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
