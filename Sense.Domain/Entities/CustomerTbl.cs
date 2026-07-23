using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class CustomerTbl : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUserTbl? ApplicationUser { get; set; }

        public ICollection<AppointmentTbl> Appointments { get; set; } = new List<AppointmentTbl>();
        public ICollection<TransactionTbl> Transactions { get; set; } = new List<TransactionTbl>();
        public ICollection<CashbackOfferUsageTbl> CashbackOfferUsages { get; set; } = new List<CashbackOfferUsageTbl>();
        public ICollection<CouponUsageTbl> CouponUsages { get; set; } = new List<CouponUsageTbl>();
        public ICollection<CustomerActivityLog> ActivityLogs { get; set; } = new List<CustomerActivityLog>();
        public ICollection<PointsTransactionTbl> PointsTransactions { get; set; } = new List<PointsTransactionTbl>();
    }
}
