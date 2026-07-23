using Sense.Application.CartItemRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.BrandRepositories
{
    public class BrandRepository : RepositoryBase<BrandTbl>, IBrandRepository
    {
        public BrandRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateBrand(BrandTbl brand)
            => Create(brand);

        public void DeleteBrand(BrandTbl brand)
            => Delete(brand);


        public async Task<IEnumerable<BrandTbl>> GetAllBrandsAsync()
            => await FindAll().ToListAsync();


        public async Task<BrandTbl> GetBrandByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
    

        public void UpdateBrand(BrandTbl brand)
            => Update(brand);
     
    }
}
