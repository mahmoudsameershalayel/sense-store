using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Queries.GetOutOfStockItemsQuery
{
    public class GetOutOfStockItemsQuery : IRequest<ResponseResult<IEnumerable<ProductDto>>>
    {
    }
}