using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class PartnerInquiryTbl : BaseEntity
    {
        public string FullName { get; set; }
        public string BrandName { get; set; }
        public string PhoneNumber { get; set; }
        public PartnerOfferType OfferType { get; set; }
        public string Description { get; set; }
    }
}
