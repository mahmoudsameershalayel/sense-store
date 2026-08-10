using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceListingDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Queries.GetServiceListingByIdQuery
{
    public class GetServiceListingByIdQuery : IRequest<ResponseResult<ServiceListingDto>>
    {
        public int ServiceListingId { get; set; }
    }
}
