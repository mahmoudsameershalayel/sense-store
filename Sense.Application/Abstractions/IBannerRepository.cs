using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IBannerRepository
    {
        Task<IEnumerable<BannerTbl>> GetAllHomeBannersAsync();
        void CreateHomeBanner(BannerTbl banner);
        void UpdateHomeBanner(BannerTbl banner);
        void DeleteHomeBanner(BannerTbl banner);
        Task<BannerTbl> GetHomeBannerByIdAsync(int id);
    }
}
