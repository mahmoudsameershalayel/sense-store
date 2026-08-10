using Sense.Domain.DBEntities;
using Sense.Domain;
using Microsoft.EntityFrameworkCore;
using Sense.Application.RequestFeatures;

namespace Sense.Application.ServiceListingRepositories
{
    public class ServiceListingRepository : RepositoryBase<ServiceListingTbl>, IServiceListingRepository
    {
        public ServiceListingRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateServiceListing(ServiceListingTbl serviceListing)
            => Create(serviceListing);


        public void DeleteServiceListing(ServiceListingTbl serviceListing)
            => Delete(serviceListing);

        public IQueryable<ServiceListingTbl> GetAllServiceListingsAsQuery()
            => FindByCondition(x => x.IsDeleted == false).AsNoTracking().Include(x => x.ServiceProvider).ThenInclude(p => p.ApplicationUser).AsQueryable();

        public async Task<PagedList<ServiceListingTbl>> GetAllServiceListingsAsync(ServiceListingParameters serviceListingParameters)
        {
            var query = FindAll().Include(x => x.ServiceProvider).ThenInclude(p => p.ApplicationUser).AsQueryable();

            if (serviceListingParameters == null)
            {
                var itemsWithoutFilter = await query.Where(x => x.IsDeleted == false).ToListAsync();
                return PagedList<ServiceListingTbl>.ToPagedList(itemsWithoutFilter, 1, itemsWithoutFilter.Count);
            }
            // Apply filters
            if (!string.IsNullOrEmpty(serviceListingParameters.ServiceListingName))
            {
                query = query.Where(i => i.Name.Contains(serviceListingParameters.ServiceListingName));
            }

            if (serviceListingParameters.Status.HasValue)
            {
                query = query.Where(i => i.Status == serviceListingParameters.Status);
            }

            if (serviceListingParameters.ServiceProviderId.HasValue)
            {
                query = query.Where(i => i.ServiceProviderId == serviceListingParameters.ServiceProviderId);
            }


            // Fetch items with pagination
            var items = await query.Where(x => x.IsDeleted == false).ToListAsync();

            return PagedList<ServiceListingTbl>.ToPagedList(items, serviceListingParameters.PageNumber, serviceListingParameters.PageSize);
        }

        public async Task<ServiceListingTbl> GetServiceListingByIdAsync(int id)
            => await FindByCondition(x => x.Id == id && x.IsDeleted == false).Include(x => x.ServiceProvider).FirstOrDefaultAsync();


        public void UpdateServiceListing(ServiceListingTbl serviceListing)
            => Update(serviceListing);

    }
}
