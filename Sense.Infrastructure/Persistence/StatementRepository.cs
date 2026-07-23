using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.StatementRepositories
{
    public class StatementRepository : RepositoryBase<StatementTbl>, IStatementRepository
    {
        public StatementRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateStatement(StatementTbl statement)
            => Create(statement);

        public void DeleteStatement(StatementTbl statement)
            => Delete(statement);

        public async Task<IEnumerable<StatementTbl>> GetAllStatementsAsync()
            => await FindByCondition(x => x.IsDeleted == false).OrderBy(x => x.SortOrder).ToListAsync();

        public async Task<IEnumerable<StatementTbl>> GetActiveStatementsAsync()
            => await FindByCondition(x => x.IsDeleted == false && x.IsActive == true).OrderBy(x => x.SortOrder).ToListAsync();

        public async Task<StatementTbl> GetStatementByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

        public void UpdateStatement(StatementTbl statement)
            => Update(statement);
    }
}
