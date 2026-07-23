using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IContactUsRepository
    {
        Task<IEnumerable<ContactFormTbl>> GetAllContactsAsync();
        Task<ContactFormTbl> GetContactByIdAsync(int id);
        void CreateContact(ContactFormTbl contact);
        void UpdateContact(ContactFormTbl contact);
        void DeleteContact(ContactFormTbl contact);
    }
}
