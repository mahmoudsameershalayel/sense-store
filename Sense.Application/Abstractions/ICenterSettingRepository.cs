using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ICenterSettingRepository
    {
        Task<CenterSettingTbl> GetCenterSettingAsync();
        void CreateCenterSetting(CenterSettingTbl centerSetting);
        void UpdateCenterSetting(CenterSettingTbl centerSetting);
    }
}
