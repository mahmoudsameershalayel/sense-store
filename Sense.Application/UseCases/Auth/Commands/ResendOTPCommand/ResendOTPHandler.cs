using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Auth.Commands.ResendOTPCommand
{
    public class ResendOTPHandler : IRequestHandler<ResendOTPCommand, ResponseResult<PhoneVerificationTbl>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public ResendOTPHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<ResponseResult<PhoneVerificationTbl>> Handle(ResendOTPCommand request, CancellationToken cancellationToken)
        {
            var verification = await _repositoryManager.PhoneVerification.GetPhoneVerificationAsync(request.PhoneNumber);
            if (verification is null)
                return await Task.FromResult(ResponseResult<PhoneVerificationTbl>.GetResult(ResultCodeStatus.Failed, "This phone number do is not has OTP!!"));

            verification.ExpireAt = DateTime.UtcNow.AddMinutes(5);
            _repositoryManager.PhoneVerification.UpdatePhoneVerification(verification);
            await _repositoryManager.SaveAsync();
            return ResponseResult<PhoneVerificationTbl>.GetResult(ResultCodeStatus.Success, verification, $"This OTP for phone number : {request.PhoneNumber}");
        }
    }
}
