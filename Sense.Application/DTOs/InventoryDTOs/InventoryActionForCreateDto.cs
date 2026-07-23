using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.InventoryDTOs
{
    public class InventoryActionForCreateDto
    {
        public int ItemId { get; set; }

        public int StockVal { get; set; }
        public InventoryAction Action { get; set; }
    }
}
