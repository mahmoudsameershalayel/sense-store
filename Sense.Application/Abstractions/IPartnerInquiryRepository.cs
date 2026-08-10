using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IPartnerInquiryRepository
    {
        Task<IEnumerable<PartnerInquiryTbl>> GetAllPartnerInquiriesAsync();
        Task<PartnerInquiryTbl> GetPartnerInquiryByIdAsync(int id);
        void CreatePartnerInquiry(PartnerInquiryTbl inquiry);
        void UpdatePartnerInquiry(PartnerInquiryTbl inquiry);
        void DeletePartnerInquiry(PartnerInquiryTbl inquiry);
    }
}
