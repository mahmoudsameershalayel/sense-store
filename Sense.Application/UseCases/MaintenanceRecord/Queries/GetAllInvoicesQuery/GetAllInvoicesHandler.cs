using Sense.Application;
using Sense.Application.RequestFeatures;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllInvoicesQuery
{
    internal class GetAllInvoicesHandler : IRequestHandler<GetAllInvoicesQuery, ResponseResult<IEnumerable<InvoiceDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllInvoicesHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<InvoiceDto>>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
            var itemsWithMetaData = await _repositoryManager.Invoice.GetAllInvoicesAsync();
            var dtos = _mapper.Map<List<InvoiceDto>>(itemsWithMetaData);
            return ResponseResult<IEnumerable<InvoiceDto>>.GetResult(ResultCodeStatus.Success, dtos, "The data reterived successfully.");

        }
    }
}
