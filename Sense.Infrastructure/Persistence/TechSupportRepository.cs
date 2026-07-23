using Sense.Application.TechSupportRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.TechSupportRepositories
{
    public class TechSupportRepository : RepositoryBase<TechSupportTbl>, ITechSupportRepository
    {
        public TechSupportRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateTechSupport(TechSupportTbl techSupport)
            => Create(techSupport);

        public void DeleteTechSupport(TechSupportTbl techSupport)
            => Delete(techSupport);


        public async Task<IEnumerable<TechSupportTbl>> GetAllTechSupportsAsync()
            => await FindAll().Include(c => c.ApplicationUser).ToListAsync();

        public async Task<TechSupportTbl> GetTechSupportByApplicationUserId(string userId)
            => await FindByCondition(x => x.ApplicationUserId.Equals(userId)).FirstOrDefaultAsync();


        public async Task<TechSupportTbl> GetTechSupportByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(c => c.ApplicationUser).SingleOrDefaultAsync();


        public void UpdateTechSupport(TechSupportTbl techSupport)
            => Update(techSupport);

    }
}
