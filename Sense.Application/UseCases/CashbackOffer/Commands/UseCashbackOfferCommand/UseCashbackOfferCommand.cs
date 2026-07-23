using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CashbackOfferUsageDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Commands.UseCashbackOfferCommand
{
    public class UseCashbackOfferCommand : IRequest<ResponseResult<CashbackOfferUsageDto>>
    {
        public string CurrentUserId { get; set; }
        public CashbackOfferUsageForCreateDto? Dto { get; set; }

    }
}