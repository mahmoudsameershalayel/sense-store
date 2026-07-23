using Sense.Application.CouponRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.CouponUsageRepositories
{
    public class CouponUsageRepository : RepositoryBase<CouponUsageTbl>, ICouponUsageRepository
    {
        public CouponUsageRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateCouponUsage(CouponUsageTbl couponUsage)
            => Create(couponUsage);


        public void DeleteCouponUsage(CouponUsageTbl couponUsage)
            => Delete(couponUsage);


        public async Task<IEnumerable<CouponUsageTbl>> GetAllCouponUsagesAsync()
            => await FindAll().ToListAsync();


        public async Task<CouponUsageTbl> GetCouponUsageByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
    
        public void UpdateCouponUsage(CouponUsageTbl couponUsage)
            => Update(couponUsage);
      
    }
}
