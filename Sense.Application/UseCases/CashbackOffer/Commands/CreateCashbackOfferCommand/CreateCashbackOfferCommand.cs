using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.OfferCashback.Commands.CreateCashbackOfferCommand
{
    public class CreateCashbackOfferCommand : IRequest<ResponseResult<CashbackOfferDto>>
    {
        public CashbackOfferForCreateDto? Dto { get; set; }

    }
}