using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.TransactionRepositories
{
    public class TransactionRepository : RepositoryBase<TransactionTbl>, ITransactionRepository
    {
        public TransactionRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateTransaction(TransactionTbl transaction) => Create(transaction);


        public void DeleteTransaction(TransactionTbl transaction) => Delete(transaction);

        public async Task<IEnumerable<TransactionTbl>> GetAllTransactionsAsync() => await FindAll().ToListAsync();

        public async Task<TransactionTbl> GetTransactionByIdAsync(int id) => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();


        public async Task<IEnumerable<TransactionTbl>> GetTransactionsHistoryForWallet(int walletId) => await FindByCondition(x => x.WalletId == walletId).Include(x => x.Wallet).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).ToListAsync();


        public void UpdateTransaction(TransactionTbl transaction) => Update(transaction);

    }
}
