using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ShoppingCartDTOs
{
    public class CartItemForUpdateDto
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
