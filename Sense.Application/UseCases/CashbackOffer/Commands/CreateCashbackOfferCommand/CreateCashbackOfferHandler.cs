using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.OfferCashbackDTOs;
using Sense.Application.UseCases.Invoice.Commands.CreateInvoiceCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.OfferCashback.Commands.CreateCashbackOfferCommand
{
    public class CreateCashbackOfferHandler : IRequestHandler<CreateCashbackOfferCommand, ResponseResult<CashbackOfferDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateCashbackOfferHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CashbackOfferDto>> Handle(CreateCashbackOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CashbackOfferTbl>(request.Dto);
            _repositoryManager.CashbackOffer.CreateOffer(entity);

            int affectedRows = await _repositoryManager.SaveAsync();
            if (affectedRows == 0)
                return ResponseResult<CashbackOfferDto>.GetResult(ResultCodeStatus.BadRequest, $"Error occured while saving entity!!");

            var dto = _mapper.Map<CashbackOfferDto>(entity);
            return ResponseResult<CashbackOfferDto>.GetResult(ResultCodeStatus.Created, dto, $"The Offer with Id : {entity.Id} created successfully");
        }
    }
}
