using Sense.Application.ServiceProviderRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.ServiceProviderRepositories
{
    public class ServiceProviderRepository : RepositoryBase<ServiceProviderTbl>, IServiceProviderRepository
    {
        public ServiceProviderRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateServiceProvider(ServiceProviderTbl serviceProvider)
            => Create(serviceProvider);

        public void DeleteServiceProvider(ServiceProviderTbl serviceProvider)
            => Delete(serviceProvider);


        public async Task<IEnumerable<ServiceProviderTbl>> GetAllServiceProvidersAsync()
            => await FindAll().Include(c => c.ApplicationUser).ToListAsync();

        public async Task<ServiceProviderTbl> GetServiceProviderByApplicationUserId(string userId)
            => await FindByCondition(x => x.ApplicationUserId.Equals(userId)).Include(c => c.ApplicationUser).FirstOrDefaultAsync();


        public async Task<ServiceProviderTbl> GetServiceProviderByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(c => c.ApplicationUser).SingleOrDefaultAsync();


        public void UpdateServiceProvider(ServiceProviderTbl serviceProvider)
            => Update(serviceProvider);

    }
}
