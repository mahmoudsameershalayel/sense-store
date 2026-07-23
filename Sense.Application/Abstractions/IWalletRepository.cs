using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IWalletRepository
    {
        public Task<IEnumerable<WalletTbl>> GetAllWalletsAsync();
        public Task<WalletTbl> GetWalletByIdAsync(int id);
        public Task<WalletTbl> GetWalletsByCustomerId(long customerId);
        public void CreateWallet(WalletTbl wallet);
        public void UpdateWallet(WalletTbl wallet);
        public void DeleteWallet(WalletTbl wallet);
    }

}
