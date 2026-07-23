using Sense.Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ShoppingCartDTOs
{
    public class CartItemForCreateDto
    {
        public int? ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
    }
}
