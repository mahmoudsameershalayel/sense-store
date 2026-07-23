using Sense.Application.CashbackOfferRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.CashbackOfferUsageRepositories
{
    public class CashbackOfferUsageRepository : RepositoryBase<CashbackOfferUsageTbl>, ICashbackOfferUsageRepository
    {
        public CashbackOfferUsageRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateOfferUsage(CashbackOfferUsageTbl cashbackOfferUsage)
            => Create(cashbackOfferUsage);


        public void DeleteOfferUsage(CashbackOfferUsageTbl cashbackOfferUsage)
            => Delete(cashbackOfferUsage);

        public async Task<IEnumerable<CashbackOfferUsageTbl>> GetAllOfferUsagesAsync()
            => await FindAll().Include(x => x.CashbackOffer).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).ToListAsync();

        public async Task<CashbackOfferUsageTbl> GetOfferUsageByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(x => x.CashbackOffer).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).FirstOrDefaultAsync();

        public void UpdateOfferUsage(CashbackOfferUsageTbl cashbackOfferUsage)
            => Update(cashbackOfferUsage);
      
    }
}
