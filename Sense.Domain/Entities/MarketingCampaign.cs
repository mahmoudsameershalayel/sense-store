using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class MarketingCampaignTbl
    {
        public int Id { get; set; }
        public int ProductId { get; set; }      
        public ProductTbl Product { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
