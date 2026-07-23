using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Product.Queries.LoadProductsQuery
{
    public class LoadProductsQuery : IRequest<ResponseResult<IQueryable<ProductTbl>>>
    {
        public bool PublishedOnly { get; set; } = false;
        public int? ProviderId { get; set; }
    }
}