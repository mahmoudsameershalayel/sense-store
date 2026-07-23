using Sense.Application.CartItemRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.ModelRepositories
{
    public class ModelRepository : RepositoryBase<ModelTbl>, IModelRepository
    {                                                                    
        public ModelRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateBrandType(ModelTbl brandType)
            => Create(brandType);
     
        public void DeleteBrandType(ModelTbl brandType)
            => Delete(brandType);
       

        public async Task<IEnumerable<ModelTbl>> GetAllBrandTypesAsync()
            => await FindAll().Include(x => x.Brand).ToListAsync();


        public async Task<ModelTbl> GetBrandTypeByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(x => x.Brand).FirstOrDefaultAsync();

        public void UpdateBrandType(ModelTbl brandType)
            => Update(brandType);
      
    }
}
