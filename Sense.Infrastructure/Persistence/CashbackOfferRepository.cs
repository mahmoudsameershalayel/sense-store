using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.CashbackOfferRepositories
{
    public class CashbackOfferRepository : RepositoryBase<CashbackOfferTbl>, ICashbackOfferRepository
    {
        public CashbackOfferRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateOffer(CashbackOfferTbl offerCashback)
            => Create(offerCashback);
       
        public void DeleteOffer(CashbackOfferTbl offerCashback)
            => Delete(offerCashback);

        public IQueryable<CashbackOfferTbl> GetAllCashbackOffersAsQuery()
                   => FindByCondition(x => x.IsDeleted == false).AsQueryable();

        public async Task<IEnumerable<CashbackOfferTbl>> GetAllOffersAsync()
            => await FindByCondition(x => x.IsDeleted == false).ToListAsync();


        public async Task<CashbackOfferTbl> GetOfferByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();


        public void UpdateOffer(CashbackOfferTbl offerCashback)
            => Update(offerCashback);
     
    }
}
