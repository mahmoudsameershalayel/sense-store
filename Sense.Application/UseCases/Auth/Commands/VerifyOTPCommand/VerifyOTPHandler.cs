using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Auth.Commands.VerifyOTPCommand
{
    public class VerifyOTPHandler : IRequestHandler<VerifyOTPCommand, ResponseResult<PhoneVerificationTbl>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<ApplicationUserTbl> _userManager;

        public VerifyOTPHandler(IRepositoryManager repositoryManager, UserManager<ApplicationUserTbl> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }
        public async Task<ResponseResult<PhoneVerificationTbl>> Handle(VerifyOTPCommand request, CancellationToken cancellationToken)
        {
            var verification = await _repositoryManager.PhoneVerification.GetPhoneVerificationAsync(request.PhoneNumber, request.EnteredOTP);
            if (verification is null)
                return ResponseResult<PhoneVerificationTbl>.GetResult(ResultCodeStatus.Failed, "Invalid OTP");

            var user = await _userManager.Users.Where(x => x.PhoneNumber.Equals(request.PhoneNumber)).FirstOrDefaultAsync();
            if (user is null)
                return ResponseResult<PhoneVerificationTbl>.GetResult(ResultCodeStatus.NotFound, "User Not Found");
            user.IsPhoneVerified = true;
            await _userManager.UpdateAsync(user);
            _repositoryManager.PhoneVerification.DeletePhoneVerification(verification);
            await _repositoryManager.SaveAsync();

            return ResponseResult<PhoneVerificationTbl>.GetResult(ResultCodeStatus.Success, verification, "Valid OTP");
        }
    }
}