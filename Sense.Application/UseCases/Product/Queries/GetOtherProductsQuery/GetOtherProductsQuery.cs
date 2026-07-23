using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProductDTOs;
using Sense.Application.DTOs.ServiceDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Queries.GetOtherProductsQuery
{
    public class GetOtherProductsQuery : IRequest<ResponseResult<IEnumerable<ProductDto>>>
    {
        public int ProductId { get; set; }
    }
}