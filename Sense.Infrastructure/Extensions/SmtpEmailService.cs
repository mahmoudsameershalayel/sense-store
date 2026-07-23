using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Sense.Infrastructure.Extensions
{
    public interface ISmtpEmailService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody);
        Task<bool> SendOtpEmailAsync(string toEmail, string otpCode);
    }

    public class SmtpEmailService : ISmtpEmailService
    {
        private readonly IConfiguration _configuration;

        public SmtpEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            try
            {
                var host = _configuration["Smtp:Host"];
                var port = int.Parse(_configuration["Smtp:Port"] ?? "587");
                var enableSsl = bool.Parse(_configuration["Smtp:EnableSsl"] ?? "true");
                var username = _configuration["Smtp:Username"];
                var password = _configuration["Smtp:Password"];
                var fromEmail = _configuration["Smtp:FromEmail"] ?? username;
                var fromName = _configuration["Smtp:FromName"] ?? "Sense Store";

                using var client = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = enableSsl
                };

                using var message = new MailMessage
                {
                    From = new MailAddress(fromEmail!, fromName),
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                message.To.Add(toEmail);

                await client.SendMailAsync(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> SendOtpEmailAsync(string toEmail, string otpCode)
        {
            var subject = "رمز التحقق - Sense Store";
            var body = $@"
                <div style=""font-family: Almarai, Arial, sans-serif; direction: rtl; text-align: right;"">
                    <h2 style=""color:#253F8E;"">رمز التحقق الخاص بك</h2>
                    <p>استخدم الرمز التالي لإتمام العملية. الرمز صالح لمدة 5 دقائق.</p>
                    <p style=""font-size: 28px; font-weight: bold; letter-spacing: 4px; color:#061C42;"">{otpCode}</p>
                    <p style=""color:#888; font-size: 12px;"">إذا لم تطلب هذا الرمز يمكنك تجاهل هذه الرسالة.</p>
                </div>";

            return SendEmailAsync(toEmail, subject, body);
        }
    }
}
