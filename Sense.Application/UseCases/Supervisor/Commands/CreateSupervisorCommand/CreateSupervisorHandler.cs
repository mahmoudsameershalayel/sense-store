using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Sense.Application.UseCases.Supervisor.Commands.CreateSupervisorCommand
{
    public class CreateSupervisorHandler : IRequestHandler<CreateSupervisorCommand, ResponseResult<IdentityResult>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateSupervisorHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        private async Task<long> CreateSupervisor(string UserId)
        {
            var supervisor = new SupervisorTbl() { ApplicationUserId = UserId };

            _repositoryManager.Supervisor.CreateSupervisor(supervisor);
            await _repositoryManager.SaveAsync();
            return supervisor.Id;
        }

        public async Task<ResponseResult<IdentityResult>> Handle(CreateSupervisorCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUserTbl>(request.Dto);
            user.UserType = UserType.Supervisor;


            var result = await _userManager.CreateAsync(user, request.Dto.Password);
            if (result.Succeeded)
            {
                var supervisor = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.Dto.PhoneNumber);
                await _userManager.AddToRoleAsync(user, "Supervisor");
                await CreateSupervisor(supervisor.Id);
                return ResponseResult<IdentityResult>.GetResult(ResultCodeStatus.Created, result, $"The Supervisor with id : {user.Id} Created successfully");
            }
            return ResponseResult<IdentityResult>.GetResult(ResultCodeStatus.BadRequest, result, $"The Operation Failed!!");
        }


    }
}