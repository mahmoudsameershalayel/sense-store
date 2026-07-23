using Sense.Application.CategoryRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.BranchRepositories
{
    public class BranchRepository : RepositoryBase<BranchTbl>, IBranchRepository
    {
        public BranchRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateBranch(BranchTbl branch)
            => Create(branch);

        public void DeleteBranch(BranchTbl branch)
            => Delete(branch);

        public async Task<IEnumerable<BranchTbl>> GetAllBranchsAsync()
            => await FindAll().ToListAsync();

        public async Task<BranchTbl> GetBranchByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();


        public void UpdateBranch(BranchTbl branch)
            => UpdateBranch(branch);
      
    }
}
