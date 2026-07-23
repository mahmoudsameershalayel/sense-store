using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;

namespace Sense.Application.UseCases.CashbackOffer.Queries.LoadCashbackOffersQuery
{
    public class LoadCashbackOffersHandler : IRequestHandler<LoadCashbackOffersQuery, ResponseResult<IQueryable<CashbackOfferTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public LoadCashbackOffersHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IQueryable<CashbackOfferTbl>>> Handle(LoadCashbackOffersQuery request, CancellationToken cancellationToken)
        {
            var query = _repositoryManager.CashbackOffer.GetAllCashbackOffersAsQuery();
            return ResponseResult<IQueryable<CashbackOfferTbl>>.GetResult(ResultCodeStatus.Success, query, "The data retrieved successfully.");
        }
    }
}
