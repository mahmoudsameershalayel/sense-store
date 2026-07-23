using Sense.Application.ProviderRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.ProviderRepositories
{
    public class ProviderRepository : RepositoryBase<ProviderTbl>, IProviderRepository
    {
        public ProviderRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateProvider(ProviderTbl provider)
            => Create(provider);

        public void DeleteProvider(ProviderTbl provider)
            => Delete(provider);


        public async Task<IEnumerable<ProviderTbl>> GetAllProvidersAsync()
            => await FindAll().Include(c => c.ApplicationUser).ToListAsync();

        public async Task<ProviderTbl> GetProviderByApplicationUserId(string userId)
            => await FindByCondition(x => x.ApplicationUserId.Equals(userId)).Include(c => c.ApplicationUser).FirstOrDefaultAsync();


        public async Task<ProviderTbl> GetProviderByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(c => c.ApplicationUser).SingleOrDefaultAsync();


        public void UpdateProvider(ProviderTbl provider)
            => Update(provider);

    }
}
