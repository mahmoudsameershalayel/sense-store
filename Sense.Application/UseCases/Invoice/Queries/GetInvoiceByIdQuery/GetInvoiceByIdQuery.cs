using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InvoiceDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Invoice.Queries.GetInvoiceByIdQuery
{
    public class GetInvoiceByIdQuery : IRequest<ResponseResult<InvoiceDto>>
    {
        public long InvoiceNo { get; set; }
    }
}