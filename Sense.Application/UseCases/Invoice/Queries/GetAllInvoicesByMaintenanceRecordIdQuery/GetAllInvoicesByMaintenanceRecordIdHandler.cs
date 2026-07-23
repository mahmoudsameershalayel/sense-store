using Sense.Application;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.UseCases.FreeMaintenanceOffer.Queries.GetAllFreeMaintenanceOfferQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Invoice.Queries.GetAllInvoicesByMaintenanceRecordIdQuery
{
    public class GetAllInvoicesByMaintenanceRecordIdHandler : IRequestHandler<GetAllInvoicesByMaintenanceRecordIdQuery, ResponseResult<IEnumerable<InvoiceDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllInvoicesByMaintenanceRecordIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<InvoiceDto>>> Handle(GetAllInvoicesByMaintenanceRecordIdQuery request, CancellationToken cancellationToken)
        {

            var allInvoices = await _repositoryManager.Invoice.GetAllInvoicesAsync();
            var invoices = allInvoices.Where(x => x.MaintenanceRecordId == request.MaintenanceRecordId).ToList();
            var dtos = _mapper.Map<List<InvoiceDto>>(invoices);
            foreach (var dto in dtos)
            {
                if (Enum.TryParse<InvoiceType>(dto.InvoiceType, out var enumValue))
                {
                    dto.InvoiceType = enumValue switch
                    {
                        InvoiceType.SparePartInvoice => "فاتورة قطع غيار",
                        InvoiceType.LaborCostInvoice => "فاتورة أجرة عمل",
                        _ => "غير معروف"
                    };
                }
            }
            return ResponseResult<IEnumerable<InvoiceDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
