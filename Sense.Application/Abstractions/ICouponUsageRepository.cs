using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ICouponUsageRepository
    {
        Task<IEnumerable<CouponUsageTbl>> GetAllCouponUsagesAsync();
        Task<CouponUsageTbl> GetCouponUsageByIdAsync(int id);
        void CreateCouponUsage(CouponUsageTbl couponUsage);
        void UpdateCouponUsage(CouponUsageTbl couponUsage);
        void DeleteCouponUsage(CouponUsageTbl couponUsage);
    }
}
