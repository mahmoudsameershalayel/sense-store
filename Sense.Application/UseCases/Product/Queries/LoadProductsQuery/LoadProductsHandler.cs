using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Appointment.Queries.LoadAppointmentsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Queries.LoadProductsQuery
{
    public class LoadProductsHandler : IRequestHandler<LoadProductsQuery, ResponseResult<IQueryable<ProductTbl>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        public LoadProductsHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseResult<IQueryable<ProductTbl>>> Handle(LoadProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _repositoryManager.Product.GetAllProductsAsQuery();

            if (request.PublishedOnly)
                query = query.Where(x => x.Status == ProductStatus.Published);

            if (request.ProviderId.HasValue)
                query = query.Where(x => x.ProviderId == request.ProviderId);

            return ResponseResult<IQueryable<ProductTbl>>.GetResult(ResultCodeStatus.Success, query, "The data retrieved successfully.");
        }
    }
}
