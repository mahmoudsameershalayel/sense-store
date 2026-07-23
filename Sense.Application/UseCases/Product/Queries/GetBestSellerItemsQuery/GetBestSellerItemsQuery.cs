using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Queries.GetBestSellerItemsQuery
{
    public class GetBestSellerItemsQuery : IRequest<ResponseResult<IEnumerable<ProductDto>>>
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
    }
}