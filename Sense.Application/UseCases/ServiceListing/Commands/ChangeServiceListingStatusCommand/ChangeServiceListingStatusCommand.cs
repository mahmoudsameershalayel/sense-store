using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceListingDTOs;
using Sense.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Commands.ChangeServiceListingStatusCommand
{
    public class ChangeServiceListingStatusCommand : IRequest<ResponseResult<ServiceListingDto>>
    {
        public int ServiceListingId { get; set; }
        public ServiceListingStatus TargetStatus { get; set; }

        // When set, the acting user is a service provider: ownership is enforced and
        // only the provider-allowed transitions are permitted.
        public int? ActingServiceProviderId { get; set; }
    }
}
