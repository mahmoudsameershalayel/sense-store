using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.WalletRepositories
{
    public class WalletRepository : RepositoryBase<WalletTbl>, IWalletRepository
    {
        public WalletRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateWallet(WalletTbl wallet) => Create(wallet);


        public void DeleteWallet(WalletTbl wallet) => Delete(wallet);


        public async Task<IEnumerable<WalletTbl>> GetAllWalletsAsync() => await FindAll().ToListAsync();


        public async Task<WalletTbl> GetWalletByIdAsync(int id) => await FindByCondition(x => x.Id == id).Include(x => x.Customer).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Transactions).FirstOrDefaultAsync();


        public async Task<WalletTbl> GetWalletsByCustomerId(long customerId) => await FindByCondition(x => x.CustomerId == customerId).Include(x => x.Customer).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Transactions).FirstOrDefaultAsync();

        public void UpdateWallet(WalletTbl wallet) => Update(wallet);


    }
}
