using Sense.Application.RequestFeatures;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceListingDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Queries.GetAllServiceListingsQuery
{
    public class GetAllServiceListingsQuery : IRequest<ResponseResult<IEnumerable<ServiceListingDto>>>
    {
        public ServiceListingParameters ServiceListingParameters { get; set; }
    }
}
