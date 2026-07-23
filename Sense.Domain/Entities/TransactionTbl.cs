using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class TransactionTbl : BaseEntity
    {
        public decimal Amount { get; set; }
        public TransactionType? TransactionType { get; set; }
        public string? Details { get; set; }


        public int CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }

        public int WalletId { get; set; }
        public WalletTbl Wallet { get; set; }
    }
}
