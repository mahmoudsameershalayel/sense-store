using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using Microsoft.EntityFrameworkCore;
using Sense.Application.RequestFeatures;
using Sense.Infrastructure.Migrations;

namespace Sense.Application.AppointmentRepositories
{
    public class AppointmentRepository : RepositoryBase<AppointmentTbl>, IAppointmentRepository
    {
        public AppointmentRepository(SenseDbContext context) : base(context)
        {                               
        }

        public void CreateAppointment(AppointmentTbl appointment)
            => Create(appointment);


        public void DeleteAppointment(AppointmentTbl appointment)
            => Delete(appointment);

        public IQueryable<AppointmentTbl> GetAllAppointmentsAsQuery()
             => FindAll().Include(x => x.Branch).Include(x => x.Brand).Include(x => x.Service).Include(x => x.Model).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).AsQueryable();


        public async Task<PagedList<AppointmentTbl>> GetAllAppointmentsAsync(AppointmentParameters appointmentParameters)
        {
            var query = FindAll().Include(x => x.Branch).Include(x => x.Brand).Include(x => x.Model).Include(x => x.Service).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).AsQueryable();

            // Apply filters
            if (appointmentParameters.BrandId.HasValue)
            {
                query = query.Where(i => i.BrandId == appointmentParameters.BrandId);
            }

            if (appointmentParameters.ServiceId.HasValue)
            {
                query = query.Where(i => i.ServiceId == appointmentParameters.ServiceId);
            }

            if (appointmentParameters.Status.HasValue)
            {
                query = query.Where(i => i.Status == appointmentParameters.Status);
            }

            if (appointmentParameters.BranchId.HasValue)
            {
                query = query.Where(i => i.BranchId == appointmentParameters.BranchId);
            }

            query = query.OrderByDescending(x => x.CreatedAt);

            // Fetch items with pagination
            var items = await query.ToListAsync();

            return PagedList<AppointmentTbl>.ToPagedList(items, appointmentParameters.PageNumber, appointmentParameters.PageSize);

        }

        public async Task<List<AppointmentTbl>> GetAllAppointmentsAsync()
            => await FindAll().Include(x => x.Branch).Include(x => x.Brand).Include(x => x.Service).Include(x => x.Model).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).ToListAsync();

        public async Task<PagedList<AppointmentTbl>> GetAllAppointmentsAsync(AppointmentParameters appointmentParameters, int customerId)
        {
            var query = FindAll().Include(x => x.Branch).Include(x => x.Brand).Include(x => x.Service).Include(x => x.Model).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).AsQueryable();

            // Apply filters
            if (appointmentParameters.BrandId.HasValue)
            {
                query = query.Where(i => i.BrandId == appointmentParameters.BrandId);
            }

            if (appointmentParameters.ServiceId.HasValue)
            {
                query = query.Where(i => i.ServiceId == appointmentParameters.ServiceId);
            }

            if (appointmentParameters.Status.HasValue)
            {
                query = query.Where(i => i.Status == appointmentParameters.Status);
            }

            if (appointmentParameters.BranchId.HasValue)
            {
                query = query.Where(i => i.BranchId == appointmentParameters.BranchId);
            }

            query = query.Where(x => x.CustomerId == customerId);

            query = query.OrderByDescending(x => x.CreatedAt);

            // Fetch items with pagination
            var items = await query.ToListAsync();

            return PagedList<AppointmentTbl>.ToPagedList(items, appointmentParameters.PageNumber, appointmentParameters.PageSize);
        }
        public async Task<PagedList<AppointmentTbl>> GetAllSupervisorAppointmentsAsync(AppointmentParameters appointmentParameters, int supervisorId)
        {
            var query = FindAll().Include(x => x.Branch).Include(x => x.Brand).Include(x => x.Model).Include(x => x.Service).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).AsQueryable();

            // Apply filters
            if (appointmentParameters.BrandId.HasValue)
            {
                query = query.Where(i => i.BrandId == appointmentParameters.BrandId);
            }

            if (appointmentParameters.ServiceId.HasValue)
            {
                query = query.Where(i => i.ServiceId == appointmentParameters.ServiceId);
            }

            if (appointmentParameters.Status.HasValue)
            {
                query = query.Where(i => i.Status == appointmentParameters.Status);
            }

            if (appointmentParameters.BranchId.HasValue)
            {
                query = query.Where(i => i.BranchId == appointmentParameters.BranchId);
            }

            query = query.Where(x => x.SupervisorId == supervisorId);

            query = query.OrderByDescending(x => x.CreatedAt);

            // Fetch items with pagination
            var items = await query.ToListAsync();

            return PagedList<AppointmentTbl>.ToPagedList(items, appointmentParameters.PageNumber, appointmentParameters.PageSize);
        }
        public async Task<AppointmentTbl> GetAppointmentByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(x => x.Branch).Include(x => x.Brand).Include(x => x.Model).Include(x => x.Service).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Supervisor).ThenInclude(x => x.ApplicationUser).FirstOrDefaultAsync();

        public void UpdateAppointment(AppointmentTbl appointment)
            => Update(appointment);
       
    }
}
