using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.CenterSettingRepositories
{
    public class CenterSettingRepository : RepositoryBase<CenterSettingTbl>, ICenterSettingRepository
    {
        public CenterSettingRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateCenterSetting(CenterSettingTbl centerSetting)
            => Create(centerSetting);
        
        public async Task<CenterSettingTbl> GetCenterSettingAsync()
            => await FindAll().FirstOrDefaultAsync();

        public void UpdateCenterSetting(CenterSettingTbl centerSetting)
            => Update(centerSetting);
    }
}
