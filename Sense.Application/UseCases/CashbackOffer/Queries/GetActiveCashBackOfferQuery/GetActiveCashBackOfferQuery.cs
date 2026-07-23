using Sense.Application.DomainEntities;
using Sense.Application.DTOs.OfferCashbackDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Queries.GetActiveCashBackOfferQuery
{
    public class GetActiveCashBackOfferQuery : IRequest<ResponseResult<CashbackOfferDto>>
    {
        public int OrderId { get; set; }
    }
}