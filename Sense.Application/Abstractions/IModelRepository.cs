using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IModelRepository
    {
        Task<IEnumerable<ModelTbl>> GetAllBrandTypesAsync();
        Task<ModelTbl> GetBrandTypeByIdAsync(int id);
        void CreateBrandType(ModelTbl brandType);
        void UpdateBrandType(ModelTbl brandType);
        void DeleteBrandType(ModelTbl brandType);
    }
}
