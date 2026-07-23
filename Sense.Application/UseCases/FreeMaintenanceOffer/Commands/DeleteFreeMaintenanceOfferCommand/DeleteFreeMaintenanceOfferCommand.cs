using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Commands.DeleteFreeMaintenanceOfferCommand
{
    public class DeleteFreeMaintenanceOfferCommand : IRequest<ResponseResult<bool>>
    {
        public int FreeMaintenanceOfferId { get; set; }
    }
}