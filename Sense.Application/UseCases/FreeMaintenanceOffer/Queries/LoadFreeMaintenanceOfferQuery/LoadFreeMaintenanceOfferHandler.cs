using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.CashbackOffer.Queries.LoadCashbackOffersQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Queries.LoadFreeMaintenanceOfferQuery
{
    public class LoadFreeMaintenanceOfferHandler : IRequestHandler<LoadFreeMaintenanceOfferQuery, ResponseResult<IQueryable<FreeMaintenanceOfferTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public LoadFreeMaintenanceOfferHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IQueryable<FreeMaintenanceOfferTbl>>> Handle(LoadFreeMaintenanceOfferQuery request, CancellationToken cancellationToken)
        {
            var query = _repositoryManager.FreeMaintenanceOffer.GetAllFreeMaintenanceOffersAsQuery();
            return ResponseResult<IQueryable<FreeMaintenanceOfferTbl>>.GetResult(ResultCodeStatus.Success, query, "The data retrieved successfully.");
        }
    }
}
