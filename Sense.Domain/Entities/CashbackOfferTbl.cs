using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class CashbackOfferTbl : BaseEntity
    {
        public CashbackType CashbackType { get; set; }
        public decimal CashbackVal { get; set; }
        public ReturnType ReturnType { get; set; }
        public bool IsApplyOnSparePart { get; set; }
        public bool IsApplyOnLaborCost { get; set; }
        public bool IsApplyOnStore { get; set; }
        public string? ImageURL { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<CashbackOfferUsageTbl> CashbackOfferUsages { get; set; } = new List<CashbackOfferUsageTbl>();    
    }
}
