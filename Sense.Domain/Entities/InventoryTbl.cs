using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.DBEntities
{
    public class InventoryTbl
    {
        public int Id { get; set; }
        public int StockVal { get; set; }
        public InventoryAction Action { get; set; }
        public DateTime? Date { get; set; } = DateTime.UtcNow;

        public int? ItemId { get; set; }
        public ProductTbl? Item { get; set; }

    }
}
