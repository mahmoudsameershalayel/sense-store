using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IServiceProviderRepository
    {
        Task<IEnumerable<ServiceProviderTbl>> GetAllServiceProvidersAsync();
        void CreateServiceProvider(ServiceProviderTbl serviceProvider);
        void UpdateServiceProvider(ServiceProviderTbl serviceProvider);
        void DeleteServiceProvider(ServiceProviderTbl serviceProvider);
        Task<ServiceProviderTbl> GetServiceProviderByIdAsync(int id);
        Task<ServiceProviderTbl> GetServiceProviderByApplicationUserId(string userId);
    }
}
