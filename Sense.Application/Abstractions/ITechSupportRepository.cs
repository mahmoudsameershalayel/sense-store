using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ITechSupportRepository
    {
        Task<IEnumerable<TechSupportTbl>> GetAllTechSupportsAsync();
        void CreateTechSupport(TechSupportTbl techSupport);
        void UpdateTechSupport(TechSupportTbl techSupport);
        void DeleteTechSupport(TechSupportTbl techSupport);
        Task<TechSupportTbl> GetTechSupportByIdAsync(int id);
        Task<TechSupportTbl> GetTechSupportByApplicationUserId(string userId);
    }
}
