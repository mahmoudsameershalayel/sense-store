using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressTbl>> GetAllAddressesAsync();
        Task<IEnumerable<AddressTbl>> GetAddressesByCustomerId(int customerId);
        Task<AddressTbl> GetAddressAsync(int id);
        void CreateAddress(AddressTbl address);
        void UpdateAddress(AddressTbl address);
        void DeleteAddress(AddressTbl address);
        void ClearAllAddresses();
    }

}
