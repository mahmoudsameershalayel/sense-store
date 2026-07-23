using Sense.Application.FreeMaintenanceOfferRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.FreeMaintenanceEligibilityRepositoris
{
    public class FreeMaintenanceEligibilityRepository : RepositoryBase<FreeMaintenanceEligibilityTbl>, IFreeMaintenanceEligibilityRepository
    {
        public FreeMaintenanceEligibilityRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateFreeMaintenanceEligibility(FreeMaintenanceEligibilityTbl freeMaintenanceEligibility)
            => Create(freeMaintenanceEligibility);

        public void DeleteFreeMaintenanceEligibility(FreeMaintenanceEligibilityTbl freeMaintenanceEligibility)
            => Delete(freeMaintenanceEligibility);

        public async Task<IEnumerable<FreeMaintenanceEligibilityTbl>> GetAllFreeMaintenanceEligibilitysAsync()
            => await FindAll().Include(x => x.FreeMaintenanceOffer).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).ToListAsync();

        public async Task<FreeMaintenanceEligibilityTbl> GetFreeMaintenanceEligibilityAsync(int customerId, int offerId)
            => await FindByCondition(x => x.CustomerId == customerId && x.FreeMaintenanceOfferId == offerId).Include(x => x.FreeMaintenanceOffer).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).FirstOrDefaultAsync();

        public async Task<FreeMaintenanceEligibilityTbl> GetFreeMaintenanceEligibilityByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(x => x.FreeMaintenanceOffer).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).FirstOrDefaultAsync();

        public void UpdateFreeMaintenanceEligibility(FreeMaintenanceEligibilityTbl freeMaintenanceEligibility)
            => Update(freeMaintenanceEligibility);

    }
}
