using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ISupervisorRepository
    {
        Task<IEnumerable<SupervisorTbl>> GetAllSupervisorsAsync();
        void CreateSupervisor(SupervisorTbl supervisor);
        void UpdateSupervisor(SupervisorTbl supervisor);
        void DeleteSupervisor(SupervisorTbl supervisor);
        Task<SupervisorTbl> GetSupervisorByIdAsync(int id);
        Task<SupervisorTbl> GetSupervisorByApplicationUserId(string userId);
    }
}
