using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.InventoryDTOs
{
    public class InventoryActionDto
    {
        public int Id { get; set; }
        public int StockVal { get; set; }
        public InventoryAction? Action { get; set; }
        public string? CreatedAtDate { get; set; }
        public string? CreatedAtTime { get; set; }

        public long? ItemId { get; set; }
        public ProductDto? Item { get; set; }

    }
}
