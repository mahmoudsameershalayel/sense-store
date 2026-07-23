using Sense.Application.ProductRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System.Linq;
using Sense.Application.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.MaintenanceRecordRepositories
{
    public class MaintenanceRecordRepository : RepositoryBase<MaintenanceRecordTbl>, IMaintenanceRecordRepository
    {
        public MaintenanceRecordRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateMaintenanceRecord(MaintenanceRecordTbl maintenanceRecord)
            => Create(maintenanceRecord);

        public void DeleteMaintenanceRecord(MaintenanceRecordTbl maintenanceRecord)
            => Delete(maintenanceRecord);

        public IQueryable<MaintenanceRecordTbl> GetAllMaintenanceRecordsAsQuery()
            => FindAll().Include(x => x.Appointment).ThenInclude(x => x.Branch).Include(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).Include(x => x.Invoices).AsQueryable();

        public async Task<PagedList<MaintenanceRecordTbl>> GetAllMaintenanceRecordsAsync(MaintenanceRecordParameters parameters)
        {
            var query = FindAll().Include(x => x.Appointment).ThenInclude(x => x.Branch).Include(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).Include(x => x.Invoices).AsQueryable();

            if (parameters.StartDate.HasValue)
            {
                var startDate = parameters.StartDate.Value.Date;
                query = query.Where(m => m.StartDate >= startDate);
            }

            if (parameters.EndDate.HasValue)
            {

                var endDate = parameters.EndDate.Value.Date;
                var nextDay = endDate.AddDays(1);
                query = query.Where(m => m.EndDate < nextDay);
            }

            if (parameters.MinTotalCost.HasValue)
                query = query.Where(m => m.TotalCost >= parameters.MinTotalCost);

            if (parameters.MaxTotalCost.HasValue)
                query = query.Where(m => m.TotalCost <= parameters.MaxTotalCost);

            if (parameters.SupervisorId.HasValue)
                query = query.Where(m => m.SupervisorId == parameters.SupervisorId);

            if (parameters.AppointmentId.HasValue)
                query = query.Where(m => m.AppointmentId == parameters.AppointmentId);

            query = query.OrderByDescending(x => x.StartDate);

            // Fetch items with pagination
            var items = await query.ToListAsync();

            return PagedList<MaintenanceRecordTbl>.ToPagedList(items, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<MaintenanceRecordTbl>> GetCustomerMaintenanceRecordsAsync(MaintenanceRecordParameters parameters, int customerId)
        {
            var query = FindAll().Include(x => x.Appointment).ThenInclude(x => x.Branch).Include(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).Include(x => x.Invoices).AsQueryable();
            if (parameters.StartDate.HasValue)
                query = query.Where(m => m.StartDate.Value.ToString("yyyy-MM-dd") == parameters.StartDate.Value.ToString("yyyy-MM-dd"));

            if (parameters.EndDate.HasValue)
                query = query.Where(m => m.EndDate.Value.ToString("yyyy-MM-dd") == parameters.EndDate.Value.ToString("yyyy-MM-dd"));


            if (parameters.MinTotalCost.HasValue)
                query = query.Where(m => m.TotalCost >= parameters.MinTotalCost);

            if (parameters.MaxTotalCost.HasValue)
                query = query.Where(m => m.TotalCost <= parameters.MaxTotalCost);

            if (parameters.SupervisorId.HasValue)
                query = query.Where(m => m.SupervisorId == parameters.SupervisorId);

            if (parameters.AppointmentId.HasValue)
                query = query.Where(m => m.AppointmentId == parameters.AppointmentId);

            query = query.Where(m => m.Appointment.CustomerId == customerId);
            query = query.OrderByDescending(x => x.StartDate);

            // Fetch items with pagination
            var items = await query.ToListAsync();

            return PagedList<MaintenanceRecordTbl>.ToPagedList(items, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<MaintenanceRecordTbl> GetMaintenanceRecordByAppointmentIdAsync(int appointmentId)
                   => await FindByCondition(x => x.AppointmentId == appointmentId).Include(x => x.Appointment).ThenInclude(x => x.Branch).Include(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).Include(x => x.Invoices).FirstOrDefaultAsync();

        public async Task<MaintenanceRecordTbl> GetMaintenanceRecordByIdAsync(int id)
            => await FindByCondition(x => x.Id == id)
                .Include(x => x.Appointment).ThenInclude(x => x.Branch)
                .Include(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Appointment).ThenInclude(x => x.Service)
                .Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser)
                .Include(x => x.Invoices)
                .Include(x => x.CashbackUsages).ThenInclude(x => x.CashbackOffer)
                .FirstOrDefaultAsync();

        public async Task<PagedList<MaintenanceRecordTbl>> GetSupervisorMaintenanceRecordsAsync(MaintenanceRecordParameters parameters, int supervisorId)
        {
            var query = FindAll().Include(x => x.Appointment).ThenInclude(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).Include(x => x.Invoices).AsQueryable();

            if (parameters.StartDate.HasValue)
                query = query.Where(m => m.StartDate.Value.ToString("yyyy-MM-dd") == parameters.StartDate.Value.ToString("yyyy-MM-dd"));

            if (parameters.EndDate.HasValue)
                query = query.Where(m => m.EndDate.Value.ToString("yyyy-MM-dd") == parameters.EndDate.Value.ToString("yyyy-MM-dd"));


            if (parameters.MinTotalCost.HasValue)
                query = query.Where(m => m.TotalCost >= parameters.MinTotalCost);

            if (parameters.MaxTotalCost.HasValue)
                query = query.Where(m => m.TotalCost <= parameters.MaxTotalCost);

            if (parameters.SupervisorId.HasValue)
                query = query.Where(m => m.SupervisorId == parameters.SupervisorId);

            if (parameters.AppointmentId.HasValue)
                query = query.Where(m => m.AppointmentId == parameters.AppointmentId);

            query = query.Where(m => m.SupervisorId == supervisorId);
            query = query.OrderByDescending(x => x.StartDate);

            // Fetch items with pagination
            var items = await query.ToListAsync();

            return PagedList<MaintenanceRecordTbl>.ToPagedList(items, parameters.PageNumber, parameters.PageSize);
        }

        public void UpdateMaintenanceRecord(MaintenanceRecordTbl maintenanceRecord)
            => Update(maintenanceRecord);

    }
}
