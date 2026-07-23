using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
namespace Sense.Infrastructure.Extensions
{
    public interface ITwilioService
    {
        Task<bool> SendOtpAsync(string phoneNumber, string otpCode);
    }

    public class TwilioService : ITwilioService
    {
        private readonly IConfiguration _configuration;

        public TwilioService(IConfiguration configuration)
        {
            _configuration = configuration;

            var accountSid = _configuration["Twilio:AccountSid"];
            var authToken = _configuration["Twilio:AuthToken"];

            TwilioClient.Init(accountSid, authToken);
        }

        public async Task<bool> SendOtpAsync(string phoneNumber, string otpCode)
        {
            try
            {
                var messagingServiceSid = _configuration["Twilio:MessagingServiceSid"];

                var message = await MessageResource.CreateAsync(
                    body: $"رمز التحقق الخاص بك في مركز سدرا: {otpCode}\nصالح لمدة 5 دقائق.",
                    messagingServiceSid: messagingServiceSid, 
                    to: new PhoneNumber(phoneNumber)
                );

                return message.Status != MessageResource.StatusEnum.Failed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}