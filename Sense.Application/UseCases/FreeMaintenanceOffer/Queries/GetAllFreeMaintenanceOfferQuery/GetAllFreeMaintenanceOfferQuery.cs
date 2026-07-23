using Sense.Application.DomainEntities;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetAllFreeMaintenanceOfferQuery
{
    public class GetAllFreeMaintenanceOfferQuery : IRequest<ResponseResult<IEnumerable<FreeMaintenanceOfferDto>>>
    {
    }
}