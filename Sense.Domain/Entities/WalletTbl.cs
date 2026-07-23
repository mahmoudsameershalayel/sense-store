using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class WalletTbl : BaseEntity
    {
      
        public double Balance { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public int? CustomerId { get; set; }
        public CustomerTbl? Customer { get; set; }
        public virtual ICollection<TransactionTbl> Transactions { get; set; } = new List<TransactionTbl>();
    }
}
