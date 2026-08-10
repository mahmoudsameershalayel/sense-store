using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceListingDTOs;
using Sense.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Commands.CreateServiceListingCommand
{
    public class CreateServiceListingCommand : IRequest<ResponseResult<ServiceListingDto>>
    {
        public ServiceListingForCreateUpdateDto? Dto { get; set; }
        public ServiceListingStatus InitialStatus { get; set; } = ServiceListingStatus.Draft;
    }
}
