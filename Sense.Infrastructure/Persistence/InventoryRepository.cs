using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sense.Domain.DBEntities;
using Sense.Domain;

namespace Sense.Application.Apstracts.InventoryRepositories
{
    public class InventoryRepository : RepositoryBase<InventoryTbl>, IInventoryRepository
    {
        public InventoryRepository(SenseDbContext context) : base(context) { }
                                    
        public void CreateInventoryAction(InventoryTbl inventory)
            => Create(inventory);

        public async Task<IEnumerable<InventoryTbl>> GetAllInventoryActionsForItemIdAsync(long itemId)
            => await FindAll().Where(x => x.ItemId == itemId).Include(x => x.Item).ThenInclude(x => x.Model)
                                                             .Include(x => x.Item).ThenInclude(x => x.Brand)
                                                             .Include(x => x.Item).ThenInclude(x => x.Category)
                                                             .OrderByDescending(x => x.Date).ToListAsync();

        public async Task<IEnumerable<InventoryTbl>> GetAllInventoryActionsForItemIdAsync()
            => await FindAll().Include(x => x.Item).ThenInclude(x => x.Model)
                                                             .Include(x => x.Item).ThenInclude(x => x.Brand)
                                                             .Include(x => x.Item).ThenInclude(x => x.Category).OrderByDescending(x => x.Date).ToListAsync();

    }
}
