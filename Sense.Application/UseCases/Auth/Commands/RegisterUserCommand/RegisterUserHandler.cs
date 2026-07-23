using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.Auth.Commands.RegisterUserCommand
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, ResponseResult<IdentityResult>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public RegisterUserHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        private async Task<int> CreateCustomer(string UserId)
        {
            var customer = new CustomerTbl() { ApplicationUserId = UserId };

            _repositoryManager.ApplicationUser.CreateCustomer(customer);
            await _repositoryManager.SaveAsync();
            return customer.Id;
        }

        public async Task<ResponseResult<IdentityResult>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUserTbl>(request.Dto);
            user.UserType = UserType.Customer;
            user.UserName = request.Dto.Email;

            var result = await _userManager.CreateAsync(user, request.Dto.Password);
            if (result.Succeeded)
            {
                var createdUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Dto.Email);
                await _userManager.AddToRoleAsync(createdUser, "Customer");
                int customerId = await CreateCustomer(createdUser.Id);
                var wallet = new WalletTbl
                {
                    CustomerId = customerId,
                    Balance = 0,
                    CreatedAt = DateTime.UtcNow
                };

                _repositoryManager.Wallet.CreateWallet(wallet);
                await _repositoryManager.SaveAsync();

                return ResponseResult<IdentityResult>.GetResult(ResultCodeStatus.Created, result, $"تم تسجيل المستخدم بنجاح. معرف المستخدم: {user.Id}");
            }
            var errors = result.Errors.Select(error => error.Description).ToList();
            var errorMessage = string.Join(" | ", errors);
            return ResponseResult<IdentityResult>.GetResult(ResultCodeStatus.BadRequest, result, $"فشل التسجيل: {errorMessage}");
        }
    }
}