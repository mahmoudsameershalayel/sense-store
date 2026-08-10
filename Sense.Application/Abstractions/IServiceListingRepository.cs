using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IServiceListingRepository
    {
        IQueryable<ServiceListingTbl> GetAllServiceListingsAsQuery();
        Task<PagedList<ServiceListingTbl>> GetAllServiceListingsAsync(ServiceListingParameters serviceListingParameters);
        void CreateServiceListing(ServiceListingTbl serviceListing);
        void UpdateServiceListing(ServiceListingTbl serviceListing);
        void DeleteServiceListing(ServiceListingTbl serviceListing);
        Task<ServiceListingTbl> GetServiceListingByIdAsync(int id);
    }
}
