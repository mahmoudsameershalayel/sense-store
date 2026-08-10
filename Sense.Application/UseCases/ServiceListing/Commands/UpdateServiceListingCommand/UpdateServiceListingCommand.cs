using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ServiceListingDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Commands.UpdateServiceListingCommand
{
    public class UpdateServiceListingCommand : IRequest<ResponseResult<ServiceListingDto>>
    {
        public int ServiceListingId { get; set; }
        public ServiceListingForCreateUpdateDto? Dto { get; set; }
    }
}
