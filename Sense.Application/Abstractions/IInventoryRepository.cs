using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryTbl>> GetAllInventoryActionsForItemIdAsync(long itemId);
        Task<IEnumerable<InventoryTbl>> GetAllInventoryActionsForItemIdAsync();
        void CreateInventoryAction(InventoryTbl inventory);
    }
}
