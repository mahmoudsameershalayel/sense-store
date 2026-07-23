using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IBrandRepository
    {
        Task<IEnumerable<BrandTbl>> GetAllBrandsAsync();
        Task<BrandTbl> GetBrandByIdAsync(int id);
        void CreateBrand(BrandTbl brand);
        void UpdateBrand(BrandTbl brand);
        void DeleteBrand(BrandTbl brand);
    }
}
