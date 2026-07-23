using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.ConnectionRepositories
{
    public class ConnectionRepository : RepositoryBase<ConnectionTbl>, IConnectionRepository
    {
        public ConnectionRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateConnection(ConnectionTbl connection)
            => Create(connection);
       

        public void DeleteConnection(ConnectionTbl connection)
            => Delete(connection);

        public async Task<IEnumerable<ConnectionTbl>> GetAllConnectionsAsync()
            => await FindAll().ToListAsync();

        public async Task<ConnectionTbl> GetConnectionByConnectionId(string connectionId)
            => await FindByCondition(x => x.ConnectionId.Equals(connectionId)).FirstOrDefaultAsync();
       
        public async Task<IEnumerable<ConnectionTbl>> GetConnectionsByUserIdAsync(string userId)
            => await FindByCondition(x => x.UserId.Equals(userId)).ToListAsync();
     
        public void UpdateConnection(ConnectionTbl connection)
            => Update(connection);
       
    }
}
