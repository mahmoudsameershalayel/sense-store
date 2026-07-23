using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.FreeMaintenanceEligibilityDTOs;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Commands.ActivateFreeMaintenanceOfferCommand
{
    public class ActivateFreeMaintenanceOfferCommand : IRequest<ResponseResult<FreeMaintenanceEligibilityDto>>
    {
        public ActivateFreeMaintenanceOfferDto Dto { get; set; }
    }
}