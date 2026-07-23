using Sense.Application.SupervisorRepositories;
using Sense.Domain;
using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.SupervisorActivityLogRepositories
{
    public class SupervisorActivityLogRepository : RepositoryBase<SupervisorActivityLog>, ISupervisorActivityLogRepository
    {
        public SupervisorActivityLogRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateSupervisorActivityLog(SupervisorActivityLog activity)
            => Create(activity);

        public void DeleteSupervisorActivityLog(SupervisorActivityLog activity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupervisorActivityLog>> GetAllSupervisorActivityLogsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SupervisorActivityLog> GetSupervisorActivityLogByApplicationUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<SupervisorActivityLog> GetSupervisorActivityLogByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
