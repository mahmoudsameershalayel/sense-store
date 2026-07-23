using Sense.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.Abstractions
{
    public interface IPhoneVerificationRepository
    {
        Task<IEnumerable<PhoneVerificationTbl>> GetAllVerificationsAsync();
        Task<PhoneVerificationTbl> GetPhoneVerificationAsync(string phoneNumber, string OTP);
        Task<PhoneVerificationTbl> GetPhoneVerificationAsync(string phoneNumber);
        void CreatePhoneVerification(PhoneVerificationTbl verification);
        void UpdatePhoneVerification(PhoneVerificationTbl verification);
        void DeletePhoneVerification(PhoneVerificationTbl verification);
        void ClearAllPhoneVerifications();
    }
}
