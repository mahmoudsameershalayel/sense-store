using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ProductDTOs
{
    public class ProductStockForUpdateDto
    {
        public int ItemId { get; set; }
        public int NewStockVal { get; set; }
    }
}
