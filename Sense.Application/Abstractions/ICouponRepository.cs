using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ICouponRepository
    {
        Task<IEnumerable<CouponTbl>> GetAllCouponsAsync();
        Task<CouponTbl> GetCouponByIdAsync(int id);
        Task<CouponTbl> GetCouponAsync(string couponCode);
        void CreateCoupon(CouponTbl coupon);
        void UpdateCoupon(CouponTbl coupon);
        void DeleteCoupon(CouponTbl coupon);
    }
}
