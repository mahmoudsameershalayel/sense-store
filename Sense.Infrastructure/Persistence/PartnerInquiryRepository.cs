using Sense.Domain.DBEntities;
using Sense.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sense.Application.PartnerInquiryRepositories
{
    public class PartnerInquiryRepository : RepositoryBase<PartnerInquiryTbl>, IPartnerInquiryRepository
    {
        public PartnerInquiryRepository(SenseDbContext context) : base(context)
        {
        }

        public void CreatePartnerInquiry(PartnerInquiryTbl inquiry)
            => Create(inquiry);

        public void DeletePartnerInquiry(PartnerInquiryTbl inquiry)
            => Delete(inquiry);

        public async Task<IEnumerable<PartnerInquiryTbl>> GetAllPartnerInquiriesAsync()
            => await FindAll().OrderByDescending(x => x.CreatedAt).ToListAsync();

        public async Task<PartnerInquiryTbl> GetPartnerInquiryByIdAsync(int id)
            => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

        public void UpdatePartnerInquiry(PartnerInquiryTbl inquiry)
            => Update(inquiry);

    }
}
