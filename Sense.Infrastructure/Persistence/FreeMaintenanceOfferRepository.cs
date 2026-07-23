using Sense.Application.CategoryRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.FreeMaintenanceOfferRepositories
{
    public class FreeMaintenanceOfferRepository : RepositoryBase<FreeMaintenanceOfferTbl>, IFreeMaintenanceOfferRepository
    {
        public FreeMaintenanceOfferRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateFreeMaintenanceOffer(FreeMaintenanceOfferTbl freeMaintenanceOffer)
            => Create(freeMaintenanceOffer);

        public void DeleteFreeMaintenanceOffer(FreeMaintenanceOfferTbl freeMaintenanceOffer)
            => Delete(freeMaintenanceOffer);

        public IQueryable<FreeMaintenanceOfferTbl> GetAllFreeMaintenanceOffersAsQuery()
            => FindByCondition(x => x.IsDeleted == false).AsQueryable();

        public async Task<IEnumerable<FreeMaintenanceOfferTbl>> GetAllFreeMaintenanceOffersAsync()
            => await FindByCondition(x => x.IsDeleted == false).ToListAsync();


        public async Task<FreeMaintenanceOfferTbl> GetFreeMaintenanceOfferByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();


        public void UpdateFreeMaintenanceOffer(FreeMaintenanceOfferTbl freeMaintenanceOffer)
            => Update(freeMaintenanceOffer);
      
    }
}
