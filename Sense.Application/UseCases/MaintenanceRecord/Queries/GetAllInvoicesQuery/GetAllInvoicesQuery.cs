using Sense.Application.RequestFeatures;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InvoiceDTOs;
using Sense.Application.DTOs.MaintenanceRecordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.GetAllInvoicesQuery
{
    public class GetAllInvoicesQuery : IRequest<ResponseResult<IEnumerable<InvoiceDto>>>
    {
        public string CurrentUserId { get; set; }
    }

}