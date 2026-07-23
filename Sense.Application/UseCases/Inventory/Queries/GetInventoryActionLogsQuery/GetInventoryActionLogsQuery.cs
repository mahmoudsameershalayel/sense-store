using Sense.Application.DomainEntities;
using Sense.Application.DTOs.InventoryDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Inventory.Queries.GetInventoryActionLogsQuery
{
    public class GetInventoryActionLogsQuery : IRequest<ResponseResult<IEnumerable<InventoryActionDto>>>
    {
        public string? StoreId { get; set; }
        public long ItemId { get; set; }
    }
}
