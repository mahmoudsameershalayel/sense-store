using Sense.Application.DomainEntities;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Queries.GetAllCashbackOffersQuery
{
    public class GetAllCashbackOffersQuery : IRequest<ResponseResult<IEnumerable<CashbackOfferDto>>>
    {
    }
}