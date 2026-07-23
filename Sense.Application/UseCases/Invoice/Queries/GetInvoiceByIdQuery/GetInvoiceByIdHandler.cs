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

namespace Sense.Application.UseCases.Invoice.Queries.GetInvoiceByIdQuery
{
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdQuery, ResponseResult<InvoiceDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetInvoiceByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<InvoiceDto>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _repositoryManager.Invoice.GetInvoiceByIdAsync(request.InvoiceNo);
            if (invoice is null)
                return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.NotFound, "Invoice Not Found!");

            var dto = _mapper.Map<InvoiceDto>(invoice);
            return ResponseResult<InvoiceDto>.GetResult(ResultCodeStatus.Success, dto, "Invoice retrieved successfully.");
        }
    }
}