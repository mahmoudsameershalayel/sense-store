using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryTbl>> GetAllCategoriesAsync();
        Task<CategoryTbl> GetCategoryByIdAsync(int id);
        void CreateCategory(CategoryTbl category);
        void UpdateCategory(CategoryTbl category);
        void DeleteCategory(CategoryTbl category);
    }
}
