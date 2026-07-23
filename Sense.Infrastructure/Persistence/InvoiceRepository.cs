using Sense.Domain.DBEntities;
using Sense.Domain;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.InvoiceRepositories
{
    public class InvoiceRepository : RepositoryBase<InvoiceTbl>, IInvoiceRepository
    {
        public InvoiceRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateInvoice(InvoiceTbl invoice)
            => Create(invoice);

        public void DeleteInvoice(InvoiceTbl invoice)
            => Delete(invoice);

        public IQueryable<InvoiceTbl> GetAllInvoicesAsQuery()
                  => FindAll()
                      .Include(x => x.Order).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
                      .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Appointment).ThenInclude(x => x.Branch)
                      .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
                      .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Supervisor).ThenInclude(x => x.ApplicationUser)
                      .OrderByDescending(x => x.CreatedAt)
                      .AsQueryable();

        public async Task<IEnumerable<InvoiceTbl>> GetAllInvoicesAsync()
            => await FindAll()
                .Include(x => x.Order).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
                .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Appointment).ThenInclude(x => x.Branch)
                .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
                .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Supervisor).ThenInclude(x => x.ApplicationUser)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();


        public async Task<InvoiceTbl> GetInvoiceByIdAsync(long invoiceNo)
            => await FindByCondition(x => x.InvoiceNo == invoiceNo)
                .Include(x => x.Order).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
                .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Appointment).ThenInclude(x => x.Branch)
                .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
                .Include(x => x.MaintenanceRecord).ThenInclude(x => x.Supervisor).ThenInclude(x => x.ApplicationUser)
                .FirstOrDefaultAsync();


        public void UpdateInvoice(InvoiceTbl invoice)
            => Update(invoice);
      
    }
}
