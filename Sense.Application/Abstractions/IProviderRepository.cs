using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IProviderRepository
    {
        Task<IEnumerable<ProviderTbl>> GetAllProvidersAsync();
        void CreateProvider(ProviderTbl provider);
        void UpdateProvider(ProviderTbl provider);
        void DeleteProvider(ProviderTbl provider);
        Task<ProviderTbl> GetProviderByIdAsync(int id);
        Task<ProviderTbl> GetProviderByApplicationUserId(string userId);
    }
}
