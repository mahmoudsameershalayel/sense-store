using Sense.Application.RequestFeatures;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IApplicationUserRepository
    {
        Task<PagedList<ApplicationUserTbl>> GetAllUsers(UserType? userType , UserParameters? userParameters);
        Task<PagedList<CustomerTbl>> GetAllCustomersAsync(UserParameters? userParameters);
        void CreateCustomer(CustomerTbl customer);
        void UpdateCustomer(CustomerTbl customer);
        void DeleteCustomer(CustomerTbl customer);
        Task<CustomerTbl> GetCustomerByIdAsync(int id);
        Task<CustomerTbl> GetCustomerByApplicationUserId(string userId);
    }
}
