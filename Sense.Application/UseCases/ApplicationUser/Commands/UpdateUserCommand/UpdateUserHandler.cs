using Sense.Application;
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

namespace Sense.Application.UseCases.ApplicationUser.Commands.UpdateUserCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResponseResult<UserDto>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UpdateUserHandler(UserManager<ApplicationUserTbl> userManager, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }



        public async Task<ResponseResult<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            string[] name = request.Dto.FullName.Split(' ');

            string firstName = name[0];
            string lastName = name[1];

            user.FirstName = firstName;
            user.LastName = lastName;
            user.UserName = request.Dto.Username;
            user.Email = request.Dto.Email;
            user.PhoneNumber = request.Dto.PhoneNumber;
            user.Phone1 = request.Dto.Phone1;
            user.Phone2 = request.Dto.Phone2;

            var result = await _userManager.UpdateAsync(user);


            if (result.Succeeded)
            {
                var dto = _mapper.Map<UserDto>(user);
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.Success, dto, $"The User with id : {user.Id} Updated successfully");
            }
            return ResponseResult<UserDto>.GetResult(ResultCodeStatus.BadRequest, $"The Operation Failed!!");
        }


    }
}