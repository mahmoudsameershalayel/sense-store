using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.AddressRepositories
{
    public class AddressRepository : RepositoryBase<AddressTbl>, IAddressRepository
    {
        public AddressRepository(SenseDbContext context) : base(context)
        {
        }

        public void ClearAllAddresses() => ClearAll();

        public void CreateAddress(AddressTbl address) => Create(address);

        public void DeleteAddress(AddressTbl address) => Delete(address);

        public async Task<IEnumerable<AddressTbl>> GetAllAddressesAsync() => await FindAll().Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Customer).Where(x => x.IsDeleted == false).ToListAsync();

        public async Task<AddressTbl> GetAddressAsync(int id) => await FindByCondition(x => x.Id == id).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Customer).Where(x => x.IsDeleted == false).FirstOrDefaultAsync();

        public void UpdateAddress(AddressTbl address) => Update(address);

        public async Task<IEnumerable<AddressTbl>> GetAddressesByCustomerId(int customerId) => await FindByCondition(x => x.CustomerId == customerId).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).Include(x => x.Customer).Where(x => x.IsDeleted == false).ToListAsync();

    }

}
