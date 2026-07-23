using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions    
{
    public interface IFreeMaintenanceOfferRepository
    {
        Task<IEnumerable<FreeMaintenanceOfferTbl>> GetAllFreeMaintenanceOffersAsync();
        IQueryable<FreeMaintenanceOfferTbl> GetAllFreeMaintenanceOffersAsQuery();
        Task<FreeMaintenanceOfferTbl> GetFreeMaintenanceOfferByIdAsync(int id);
        void CreateFreeMaintenanceOffer(FreeMaintenanceOfferTbl freeMaintenanceOffer);
        void UpdateFreeMaintenanceOffer(FreeMaintenanceOfferTbl freeMaintenanceOffer);
        void DeleteFreeMaintenanceOffer(FreeMaintenanceOfferTbl freeMaintenanceOffer);
    }
}
