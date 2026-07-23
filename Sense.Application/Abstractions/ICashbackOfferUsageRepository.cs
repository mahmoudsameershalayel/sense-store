using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ICashbackOfferUsageRepository
    {
        Task<IEnumerable<CashbackOfferUsageTbl>> GetAllOfferUsagesAsync();
        Task<CashbackOfferUsageTbl> GetOfferUsageByIdAsync(int id);
        void CreateOfferUsage(CashbackOfferUsageTbl cashbackOfferUsage);
        void UpdateOfferUsage(CashbackOfferUsageTbl cashbackOfferUsage);
        void DeleteOfferUsage(CashbackOfferUsageTbl cashbackOfferUsage);
    }
}
