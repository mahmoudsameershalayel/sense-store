using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InvoiceDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Invoice.Commands.UpdateInvoiceCommand
{
    public class UpdateInvoiceCommand : IRequest<ResponseResult<InvoiceDto>>
    {
        public InvoiceForUpdateDto Dto { get; set; }
    }
}