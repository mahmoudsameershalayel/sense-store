using Sense.Domain.DBEntities;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Order.Queries.LoadOrdersQuery
{
    public class LoadOrdersQuery : IRequest<ResponseResult<IQueryable<OrderTbl>>>
    {
        public string? CurrentUserId { get; set; }

    }
}