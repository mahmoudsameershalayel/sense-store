using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InvoiceDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Invoice.Commands.UpdateInvoiceCommand
{
    public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand, ResponseResult<InvoiceDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateInvoiceHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<InvoiceDto>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _repositoryManager.Invoice.GetInvoiceByIdAsync(request.Dto.InvoiceNo);
            if (invoice is null)
                return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.NotFound, "Invoice Not Found!");

            // Update invoice properties
            invoice.InvoiceAmount = request.Dto.InvoiceAmount;
            invoice.InvoiceType = request.Dto.InvoiceType;

            _repositoryManager.Invoice.UpdateInvoice(invoice);
            await _repositoryManager.SaveAsync();

            var dto = _mapper.Map<InvoiceDto>(invoice);
            return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.Success, dto, "Invoice updated successfully.");
        }
    }
}