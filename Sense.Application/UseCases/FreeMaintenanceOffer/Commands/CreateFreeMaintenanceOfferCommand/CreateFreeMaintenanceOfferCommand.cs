using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.FreeMaintenanceOffer.Commands.CreateFreeMaintenanceOfferCommand
{
    public class CreateFreeMaintenanceOfferCommand : IRequest<ResponseResult<FreeMaintenanceOfferDto>>
    {
        public FreeMaintenanceOfferForCreateDto? Dto { get; set; }

    }
}