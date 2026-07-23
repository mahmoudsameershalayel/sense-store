using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.MaintenanceRecord.Queries.LoadInvoicesQuery
{
    public class LoadInvoicesQuery : IRequest<ResponseResult<IQueryable<InvoiceTbl>>>
    {
        public string? CurrentUserId { get; set; }
    }
}