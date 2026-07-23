using Sense.Application.RequestFeatures;
using Sense.Domain;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.ApplicationUserRepositories
{
    public class ApplicationUserRepository : RepositoryBase<CustomerTbl>, IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        public ApplicationUserRepository(SenseDbContext context , UserManager<ApplicationUserTbl> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<PagedList<CustomerTbl>> GetAllCustomersAsync(UserParameters? userParameters)
        {
            if (userParameters == null)
            {
                var allUsers = await FindAll().Include(c => c.ApplicationUser).ToListAsync();
                return PagedList<CustomerTbl>.ToPagedList(allUsers);

            }

            var query = FindAll().Include(x => x.ApplicationUser).AsQueryable();
            if (!string.IsNullOrEmpty(userParameters.Name))
                query = query.Where(i => i.ApplicationUser.FirstName.Contains(userParameters.Name) || i.ApplicationUser.LastName.Contains(userParameters.Name) || i.ApplicationUser.UserName.Contains(userParameters.Name));
        
            query = query.OrderByDescending(x => x.CreatedAt);
            var items = await query.ToListAsync();
            return PagedList<CustomerTbl>.ToPagedList(items, userParameters.PageNumber, userParameters.PageSize);

        }
        public async Task<CustomerTbl> GetCustomerByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).Include(c => c.ApplicationUser).SingleOrDefaultAsync();
        public async Task<CustomerTbl> GetCustomerByApplicationUserId(string userId)
            => await FindByCondition(x => x.ApplicationUserId.Equals(userId)).Include(x => x.ApplicationUser).FirstOrDefaultAsync();

        public void UpdateCustomer(CustomerTbl customer) => Update(customer);

        public void CreateCustomer(CustomerTbl customer) => Create(customer);
        public void DeleteCustomer(CustomerTbl customer) => Delete(customer);

        public async Task<PagedList<ApplicationUserTbl>> GetAllUsers(UserType? userType , UserParameters? userParameters)
        {
            if (userParameters == null)
            {
                var allUsers = await _userManager.Users.Where(x => x.UserType == userType).ToListAsync();
                return PagedList<ApplicationUserTbl>.ToPagedList(allUsers);

            }

            var query = _userManager.Users.Where(x => x.UserType == userType).AsQueryable();
            if (!string.IsNullOrEmpty(userParameters.Name))
                query = query.Where(i => i.FirstName.Contains(userParameters.Name) || i.LastName.Contains(userParameters.Name) || i.UserName.Contains(userParameters.Name));

            var items = await query.ToListAsync();
            return PagedList<ApplicationUserTbl>.ToPagedList(items, userParameters.PageNumber, userParameters.PageSize);
        }
    }
}
