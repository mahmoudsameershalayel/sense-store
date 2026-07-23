using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IConnectionRepository
    {
        Task<IEnumerable<ConnectionTbl>> GetAllConnectionsAsync();
        Task<ConnectionTbl> GetConnectionByConnectionId(string connectionId);
        Task<IEnumerable<ConnectionTbl>> GetConnectionsByUserIdAsync(string userId);
        void CreateConnection(ConnectionTbl connection);
        void UpdateConnection(ConnectionTbl connection);
        void DeleteConnection(ConnectionTbl connection);
    }
}
