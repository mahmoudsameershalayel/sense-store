using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<ResponseResult<ProductDto>>
    {
        public int ProductId { get; set; }
        public ProductForCreateUpdateDto? Dto { get; set; }

    }
}