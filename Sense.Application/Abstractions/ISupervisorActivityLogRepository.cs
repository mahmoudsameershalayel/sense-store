using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ISupervisorActivityLogRepository
    {
        Task<IEnumerable<SupervisorActivityLog>> GetAllSupervisorActivityLogsAsync();
        void CreateSupervisorActivityLog(SupervisorActivityLog activity);
        void DeleteSupervisorActivityLog(SupervisorActivityLog activity);
        Task<SupervisorActivityLog> GetSupervisorActivityLogByIdAsync(int id);
        Task<SupervisorActivityLog> GetSupervisorActivityLogByApplicationUserId(string userId);
    }
}
