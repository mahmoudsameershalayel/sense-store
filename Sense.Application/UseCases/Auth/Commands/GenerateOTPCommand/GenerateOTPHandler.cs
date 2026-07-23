using Sense.Application;
using Sense.Domain.DBEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Auth.Commands.GenerateOTPCommand
{
    public class GenerateOTPHandler : IRequestHandler<GenerateOTPCommand, PhoneVerificationTbl>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GenerateOTPHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<PhoneVerificationTbl> Handle(GenerateOTPCommand request, CancellationToken cancellationToken)
        {
            var otp = new Random().Next(1000, 9999).ToString();
            var verification = new PhoneVerificationTbl()
            {
                OTP = otp,
                PhoneNumber = request.PhoneNumber,
                ExpireAt = DateTime.UtcNow.AddMinutes(5),
            };
            _repositoryManager.PhoneVerification.CreatePhoneVerification(verification);
            await _repositoryManager.SaveAsync();
            return verification;
        }
    }
}