using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Queries.LoadServiceListingsQuery
{
    public class LoadServiceListingsQuery : IRequest<ResponseResult<IQueryable<ServiceListingTbl>>>
    {
        public bool PublishedOnly { get; set; } = false;
        public int? ServiceProviderId { get; set; }
    }
}
