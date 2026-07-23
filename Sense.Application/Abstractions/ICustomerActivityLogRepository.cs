using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface ICustomerActivityLogRepository
    {
        Task<IEnumerable<CustomerActivityLog>> GetAllCustomerActivityLogsAsync();
        void CreateCustomerActivityLog(CustomerActivityLog activity);
        void DeleteCustomerActivityLog(CustomerActivityLog activity);
        Task<CustomerActivityLog> GetCustomerActivityLogByIdAsync(int id);
        Task<CustomerActivityLog> GetCustomerActivityLogByApplicationUserId(string userId);
    }
}
