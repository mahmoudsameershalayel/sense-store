using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<TransactionTbl>> GetAllTransactionsAsync();
        public Task<IEnumerable<TransactionTbl>> GetTransactionsHistoryForWallet(int walletId);
        public Task<TransactionTbl> GetTransactionByIdAsync(int id);
        public void CreateTransaction(TransactionTbl transaction);
        public void UpdateTransaction(TransactionTbl transaction);
        public void DeleteTransaction(TransactionTbl transaction);
    }

}
