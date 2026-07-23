using Sense.Domain;
using Sense.Domain.DBEntities;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Sense.Infrastructure.Extensions
{
    public interface IOtpService
    {
        Task<string> GenerateOtpAsync();
        Task StoreOtpAsync(string email, string otp);
        Task<bool> ValidateOtpAsync(string email, string otp);
        Task RemoveOtpAsync(string email);
    }

    public class OtpServiceDb : IOtpService
    {
        private readonly SenseDbContext _dbContext;
        private const int OTP_EXPIRATION_MINUTES = 5;

        public OtpServiceDb(SenseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GenerateOtpAsync()
        {
            var otp = RandomNumberGenerator.GetInt32(100000, 999999).ToString();
            return otp;
        }

        public async Task StoreOtpAsync(string email, string otp)
        {
            var existing = await _dbContext.Otps.FindAsync(email);

            if (existing != null)
            {
                existing.OtpCode = otp;
                existing.Expiration = DateTime.UtcNow.AddMinutes(OTP_EXPIRATION_MINUTES);
            }
            else
            {
                var entity = new Otp
                {
                    Email = email,
                    OtpCode = otp,
                    Expiration = DateTime.UtcNow.AddMinutes(OTP_EXPIRATION_MINUTES)
                };
                await _dbContext.Otps.AddAsync(entity);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ValidateOtpAsync(string email, string otp)
        {
            var record = await _dbContext.Otps.FindAsync(email);

            if (record == null)
                return false;

            return record.OtpCode == otp && record.Expiration > DateTime.UtcNow;
        }

        public async Task RemoveOtpAsync(string email)
        {
            var record = await _dbContext.Otps.FindAsync(email);
            if (record != null)
            {
                _dbContext.Otps.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
