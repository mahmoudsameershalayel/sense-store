using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ICashbackOfferRepository
    {
        Task<IEnumerable<CashbackOfferTbl>> GetAllOffersAsync();
        IQueryable<CashbackOfferTbl> GetAllCashbackOffersAsQuery();
        Task<CashbackOfferTbl> GetOfferByIdAsync(int id);
        void CreateOffer(CashbackOfferTbl offerCashback);
        void UpdateOffer(CashbackOfferTbl offerCashback);
        void DeleteOffer(CashbackOfferTbl offerCashback);
    }
}
