using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ServiceListing.Commands.DeleteServiceListingCommand
{
    public class DeleteServiceListingCommand : IRequest<ResponseResult<bool>>
    {
        public int ServiceListingId { get; set; }
    }
}
