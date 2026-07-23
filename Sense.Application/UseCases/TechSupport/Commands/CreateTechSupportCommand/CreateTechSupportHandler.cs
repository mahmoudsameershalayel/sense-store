using Sense.Application;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.UseCases.Supervisor.Commands.CreateSupervisorCommand;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.TechSupport.Commands.CreateTechSupportCommand
{
    public class CreateTechSupportHandler : IRequestHandler<CreateTechSupportCommand, ResponseResult<IdentityResult>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateTechSupportHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        private async Task<long> CreateTechSupport(string UserId)
        {
            var techSupport = new TechSupportTbl() { ApplicationUserId = UserId };

            _repositoryManager.TechSupport.CreateTechSupport(techSupport);
            await _repositoryManager.SaveAsync();
            return techSupport.Id;
        }

        public async Task<ResponseResult<IdentityResult>> Handle(CreateTechSupportCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUserTbl>(request.Dto);
            user.UserType = UserType.Supervisor;


            var result = await _userManager.CreateAsync(user, request.Dto.Password);
            if (result.Succeeded)
            {
                var techSupport = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.Dto.PhoneNumber);
                await _userManager.AddToRoleAsync(user, "TechSupport");
                await CreateTechSupport(techSupport.Id);
                return ResponseResult<IdentityResult>.GetResult(ResultCodeStatus.Created, result, $"The TechSupport with id : {user.Id} Created successfully");
            }
            return ResponseResult<IdentityResult>.GetResult(ResultCodeStatus.BadRequest, result, $"The Operation Failed!!");
        }


    }
}