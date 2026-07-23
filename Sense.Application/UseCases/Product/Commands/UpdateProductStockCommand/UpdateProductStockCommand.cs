using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InventoryDTOs;
using Sense.Application.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.UpdateProductStockCommand
{
    public class UpdateProductStockCommand : IRequest<ResponseResult<bool>>
    {
        public ProductStockForUpdateDto? Dto { get; set; }
    }
}
