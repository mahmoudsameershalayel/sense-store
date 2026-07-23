using Sense.Application.CategoryRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.BannerRepositories
{
    public class BannerRepository : RepositoryBase<BannerTbl>, IBannerRepository
    {
        public BannerRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateHomeBanner(BannerTbl banner)
            => Create(banner);

        public void DeleteHomeBanner(BannerTbl banner)
            => Delete(banner);


        public async Task<IEnumerable<BannerTbl>> GetAllHomeBannersAsync()
            => await FindAll().ToListAsync();


        public async Task<BannerTbl> GetHomeBannerByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

    
        public void UpdateHomeBanner(BannerTbl banner)
            => Update(banner);

    }
}
