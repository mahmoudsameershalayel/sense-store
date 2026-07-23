using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sense.Application.DomainEntities;

namespace Sense.Application.UseCases.ApplicationUser.Commands.CreateUserCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResponseResult<IdentityResult>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateUserHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        private async Task<long> CreateCustomer(string UserId)
        {
            var customer = new CustomerTbl() { ApplicationUserId = UserId };

            _repositoryManager.ApplicationUser.CreateCustomer(customer);
            await _repositoryManager.SaveAsync();
            return customer.Id;
        }
        private async Task<long> CreateTechSupport(string UserId)
        {
            var techSupport = new TechSupportTbl() { ApplicationUserId = UserId };

            _repositoryManager.TechSupport.CreateTechSupport(techSupport);
            await _repositoryManager.SaveAsync();
            return techSupport.Id;
        }

        private async Task<long> CreateSupervisor(string UserId, int? branchId)
        {
            var supervisor = new SupervisorTbl() { ApplicationUserId = UserId, BranchId = branchId };

            _repositoryManager.Supervisor.CreateSupervisor(supervisor);
            await _repositoryManager.SaveAsync();
            return supervisor.Id;
        }

        private async Task<long> CreateProvider(string UserId, string displayName, string? phoneNumber)
        {
            var provider = new ProviderTbl()
            {
                ApplicationUserId = UserId,
                DisplayName = displayName,
                PhoneNumber = phoneNumber
            };

            _repositoryManager.Provider.CreateProvider(provider);
            await _repositoryManager.SaveAsync();
            return provider.Id;
        }

        public async Task<ResponseResult<IdentityResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUserTbl>(request.Dto);
            user.UserType = request.UserType;
            user.UserName = request.Dto.Email;
            user.EmailConfirmed = true;


            var result = await _userManager.CreateAsync(user, request.Dto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, request.UserType.ToString());
                switch (request.UserType)
                {
                    case UserType.Customer:
                        await CreateCustomer(user.Id);
                        break;
                    case UserType.TechSupport:
                        await CreateTechSupport(user.Id);
                        break;
                     case UserType.Supervisor:
                        await CreateSupervisor(user.Id, request.BranchId);
                        break;
                     case UserType.Provider:
                        var providerName = !string.IsNullOrWhiteSpace(request.ProviderName)
                            ? request.ProviderName
                            : $"{request.Dto.FirstName} {request.Dto.LastName}".Trim();
                        await CreateProvider(user.Id, providerName, request.Dto.PhoneNumber);
                        break;
                      default:
                        break;
                }
                return ResponseResult<IdentityResult>.GetResult(ResultCodeStatus.Created, result, $"The User with id : {user.Id} Created successfully");
            }
            var errors = result.Errors.Select(error => error.Description).ToList();
            var errorMessage = string.Join(" | ", errors);
            return ResponseResult<IdentityResult>.GetResult(ResultCodeStatus.BadRequest, result, errorMessage);
        }


    }
}