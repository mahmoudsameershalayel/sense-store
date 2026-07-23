using Sense.Application.DomainEntities;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Commands.UpdateSupervisorCommand
{
    public class UpdateSupervisorHandler : IRequestHandler<UpdateSupervisorCommand, ResponseResult<UserDto>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateSupervisorHandler(
            UserManager<ApplicationUserTbl> userManager,
            IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ResponseResult<UserDto>> Handle(UpdateSupervisorCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Dto.Id);

            if (user == null)
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.NotFound, null, $"Supervisor with ID {request.Dto.Id} not found.");


            // Update fields
            user.FirstName = request.Dto.FirstName;
            user.LastName = request.Dto.LastName;
            user.UserName = request.Dto.Username;
            user.Email = request.Dto.Email;
            user.PhoneNumber = request.Dto.PhoneNumber;
            user.Phone1 = request.Dto.Phone1;
            user.Phone2 = request.Dto.Phone2;

            var supervisor = await _repositoryManager.Supervisor.GetSupervisorByApplicationUserId(request.Dto.Id);
            if (supervisor is null)
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.NotFound, null, $"Supervisor with ID {request.Dto.Id} not found.");


            // Supervisor-specific logic
            supervisor.BranchId = request.Dto.BranchId;
            _repositoryManager.Supervisor.UpdateSupervisor(supervisor);
            await _repositoryManager.SaveAsync();

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var dto = _mapper.Map<UserDto>(user);
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.Success, dto, $"Supervisor with ID {user.Id} updated successfully.");
            }

            return ResponseResult<UserDto>.GetResult(ResultCodeStatus.BadRequest, null, "Failed to update supervisor.");
        }
    }
}