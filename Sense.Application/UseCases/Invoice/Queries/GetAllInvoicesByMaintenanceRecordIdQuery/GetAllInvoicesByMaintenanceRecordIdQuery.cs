using Sense.Application.DomainEntities;
using Sense.Application.DTOs.FreeMaintenanceOfferDTOs;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Invoice.Queries.GetAllInvoicesByMaintenanceRecordIdQuery
{
    public class GetAllInvoicesByMaintenanceRecordIdQuery : IRequest<ResponseResult<IEnumerable<InvoiceDto>>>
    {
        public int MaintenanceRecordId { get; set; }
    }
}