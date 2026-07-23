using Sense.Application.ApplicationUserRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.SupervisorRepositories
{
    public class SupervisorRepository : RepositoryBase<SupervisorTbl>, ISupervisorRepository
    {
        public SupervisorRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateSupervisor(SupervisorTbl supervisor)
            => Create(supervisor);

        public void DeleteSupervisor(SupervisorTbl supervisor)
            => Delete(supervisor);


        public async Task<IEnumerable<SupervisorTbl>> GetAllSupervisorsAsync()
            => await FindAll().Include(c => c.ApplicationUser).ToListAsync();
       
        public async Task<SupervisorTbl> GetSupervisorByApplicationUserId(string userId)
            => await FindByCondition(x => x.ApplicationUserId.Equals(userId)).Include(c => c.ApplicationUser).Include(x => x.Branch).Include(x => x.Appointments).Include(x => x.MaintenanceRecords).Include(x => x.ActivityLogs).FirstOrDefaultAsync();

                                                        
        public async Task<SupervisorTbl> GetSupervisorByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(c => c.ApplicationUser).Include(x => x.Branch).Include(x => x.Appointments).Include(x => x.MaintenanceRecords).Include(x => x.ActivityLogs).FirstOrDefaultAsync();

      
        public void UpdateSupervisor(SupervisorTbl supervisor)
            => Update(supervisor);
      
    }
}
