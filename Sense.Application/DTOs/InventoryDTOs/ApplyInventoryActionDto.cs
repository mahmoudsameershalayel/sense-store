using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.InventoryDTOs
{
    public class ApplyInventoryActionDto
    {
        public int StockVal { get; set; }
        public InventoryAction Action { get; set; }
    }
}
