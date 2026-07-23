using Sense.Application.CategoryRepositories;
using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.ContactUsRepositories
{
    public class ContactUsRepository : RepositoryBase<ContactFormTbl>, IContactUsRepository
    {
        public ContactUsRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreateContact(ContactFormTbl contact)
            => Create(contact);


        public void DeleteContact(ContactFormTbl contact)
            => Delete(contact);


        public async Task<IEnumerable<ContactFormTbl>> GetAllContactsAsync()
            => await FindAll().ToListAsync();


        public async Task<ContactFormTbl> GetContactByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
       
        public void UpdateContact(ContactFormTbl contact)
            => Update(contact);
      
    }
}
