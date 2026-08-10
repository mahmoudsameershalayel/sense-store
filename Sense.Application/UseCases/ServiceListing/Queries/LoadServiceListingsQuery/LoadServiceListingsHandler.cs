using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Queries.LoadServiceListingsQuery
{
    public class LoadServiceListingsHandler : IRequestHandler<LoadServiceListingsQuery, ResponseResult<IQueryable<ServiceListingTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public LoadServiceListingsHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IQueryable<ServiceListingTbl>>> Handle(LoadServiceListingsQuery request, CancellationToken cancellationToken)
        {
            var query = _repositoryManager.ServiceListing.GetAllServiceListingsAsQuery();

            if (request.PublishedOnly)
                query = query.Where(x => x.Status == ServiceListingStatus.Published);

            if (request.ServiceProviderId.HasValue)
                query = query.Where(x => x.ServiceProviderId == request.ServiceProviderId);

            return ResponseResult<IQueryable<ServiceListingTbl>>.GetResult(ResultCodeStatus.Success, query, "The data retrieved successfully.");
        }
    }
}
