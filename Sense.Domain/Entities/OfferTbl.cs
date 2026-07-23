using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class OfferTbl : BaseEntity
    {
        public OfferDiscountType DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public string? ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
