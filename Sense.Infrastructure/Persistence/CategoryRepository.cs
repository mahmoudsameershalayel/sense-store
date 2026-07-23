using Sense.Application.SupervisorRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.CategoryRepositories
{
    public class CategoryRepository : RepositoryBase<CategoryTbl>, ICategoryRepository
    {
        public CategoryRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateCategory(CategoryTbl category)
            => Create(category);
     
        public void DeleteCategory(CategoryTbl category)
            => Delete(category);


        public async Task<IEnumerable<CategoryTbl>> GetAllCategoriesAsync()
            => await FindAll().ToListAsync();


        public async Task<CategoryTbl> GetCategoryByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
     
        public void UpdateCategory(CategoryTbl category)
            => Update(category);
     
    }
}
