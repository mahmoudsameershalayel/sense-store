using Sense.Application.DomainEntities;
using Sense.Application.DTOs.CategoryDTOs;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<ResponseResult<ProductDto>>
    {
        public ProductForCreateUpdateDto? Dto { get; set; }
        public ProductStatus InitialStatus { get; set; } = ProductStatus.Draft;

    }
}