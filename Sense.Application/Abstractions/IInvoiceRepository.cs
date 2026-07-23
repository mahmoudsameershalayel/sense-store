using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<InvoiceTbl>> GetAllInvoicesAsync();
        IQueryable<InvoiceTbl> GetAllInvoicesAsQuery();
        void CreateInvoice(InvoiceTbl invoice);
        void UpdateInvoice(InvoiceTbl invoice);
        void DeleteInvoice(InvoiceTbl invoice);
        Task<InvoiceTbl> GetInvoiceByIdAsync(long invoiceNo);
    }
}
