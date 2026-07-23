using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Commands.UpdateCashbackOfferStatusCommand
{
    public class UpdateCashbackOfferStatusCommand : IRequest<ResponseResult<bool>>
    {
        public int OfferId { get; set; }
    }
}
