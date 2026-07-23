using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IFreeMaintenanceEligibilityRepository
    {
        Task<IEnumerable<FreeMaintenanceEligibilityTbl>> GetAllFreeMaintenanceEligibilitysAsync();
        Task<FreeMaintenanceEligibilityTbl> GetFreeMaintenanceEligibilityByIdAsync(int id);
        Task<FreeMaintenanceEligibilityTbl> GetFreeMaintenanceEligibilityAsync(int customerId , int offerId);
        void CreateFreeMaintenanceEligibility(FreeMaintenanceEligibilityTbl freeMaintenanceEligibility);
        void UpdateFreeMaintenanceEligibility(FreeMaintenanceEligibilityTbl freeMaintenanceEligibility);
        void DeleteFreeMaintenanceEligibility(FreeMaintenanceEligibilityTbl freeMaintenanceEligibility);
    }
}
