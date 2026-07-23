using Sense.Application.SupervisorActivityLogRepositories;
using Sense.Domain;
using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.CustomerActivityLogRepositories
{
    public class CustomerActivityLogRepository : RepositoryBase<CustomerActivityLog>, ICustomerActivityLogRepository
    {
        public CustomerActivityLogRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateCustomerActivityLog(CustomerActivityLog activity)
            => Create(activity);

        public void DeleteCustomerActivityLog(CustomerActivityLog activity)
            => Delete(activity);

        public Task<IEnumerable<CustomerActivityLog>> GetAllCustomerActivityLogsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerActivityLog> GetCustomerActivityLogByApplicationUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerActivityLog> GetCustomerActivityLogByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
