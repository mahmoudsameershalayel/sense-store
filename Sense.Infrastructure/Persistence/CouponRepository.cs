using Sense.Application.CategoryRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.CouponRepositories
{
    public class CouponRepository : RepositoryBase<CouponTbl>, ICouponRepository
    {
        public CouponRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateCoupon(CouponTbl coupon)
            => Create(coupon);

        public void DeleteCoupon(CouponTbl coupon)
            => Delete(coupon);

        public async Task<IEnumerable<CouponTbl>> GetAllCouponsAsync()
            => await FindByCondition(x => x.IsDeleted == false).ToListAsync();

        public async Task<CouponTbl> GetCouponAsync(string couponCode)
            => await FindByCondition(x => x.CouponCode.Equals(couponCode) && x.IsActive == true && x.IsDeleted == false ).FirstOrDefaultAsync();

        public async Task<CouponTbl> GetCouponByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

        public void UpdateCoupon(CouponTbl coupon)
            => Update(coupon);
       
    }
}
