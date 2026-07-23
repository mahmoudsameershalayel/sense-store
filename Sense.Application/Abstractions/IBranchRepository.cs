using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IBranchRepository
    {
        Task<IEnumerable<BranchTbl>> GetAllBranchsAsync();
        void CreateBranch(BranchTbl branch);
        void UpdateBranch(BranchTbl branch);
        void DeleteBranch(BranchTbl branch);
        Task<BranchTbl> GetBranchByIdAsync(int id);
    }
}
