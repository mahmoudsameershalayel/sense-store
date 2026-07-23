using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IStatementRepository
    {
        Task<IEnumerable<StatementTbl>> GetAllStatementsAsync();
        Task<IEnumerable<StatementTbl>> GetActiveStatementsAsync();
        Task<StatementTbl> GetStatementByIdAsync(int id);
        void CreateStatement(StatementTbl statement);
        void UpdateStatement(StatementTbl statement);
        void DeleteStatement(StatementTbl statement);
    }
}
