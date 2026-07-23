using Sense.Domain;
using Sense.Domain.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.PhoneVerificationRepositories
{
    public class PhoneVerificationRepository : RepositoryBase<PhoneVerificationTbl>, IPhoneVerificationRepository
    {
        public PhoneVerificationRepository(SenseDbContext context) : base(context)
        {

        }

        public void ClearAllPhoneVerifications()
        {
            throw new NotImplementedException();
        }

        public void CreatePhoneVerification(PhoneVerificationTbl verification)
            => Create(verification);

        public void DeletePhoneVerification(PhoneVerificationTbl verification)
            => Delete(verification);

        public async Task<IEnumerable<PhoneVerificationTbl>> GetAllVerificationsAsync()
            => await FindAll().ToListAsync();

        public async Task<PhoneVerificationTbl> GetPhoneVerificationAsync(string phoneNumber, string OTP)
             => await FindByCondition(x => x.PhoneNumber.Equals(phoneNumber) && x.OTP.Equals(OTP) && x.ExpireAt > DateTime.UtcNow).FirstOrDefaultAsync();

        public async Task<PhoneVerificationTbl> GetPhoneVerificationAsync(string phoneNumber)
              => await FindByCondition(x => x.PhoneNumber.Equals(phoneNumber)).FirstOrDefaultAsync();


        public void UpdatePhoneVerification(PhoneVerificationTbl verification)
        => Update(verification);

    }
}
