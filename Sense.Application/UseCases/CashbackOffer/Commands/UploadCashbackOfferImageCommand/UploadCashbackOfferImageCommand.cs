using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CashbackOfferDTOs;
using Sense.Application.DTOs.CategoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.CashbackOffer.Commands.UploadCashbackOfferImageCommand
{
    public class UploadCashbackOfferImageCommand : IRequest<ResponseResult<string>>
    {
        public UploadCashbackOfferImageDto? Dto { get; set; }

    }
}
