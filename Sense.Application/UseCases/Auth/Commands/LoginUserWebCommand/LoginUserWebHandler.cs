using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sense.Application.UseCases.Auth.Commands.LoginUserWebCommand
{
    public class LoginUserWebHandler : IRequestHandler<LoginUserWebCommand, ResponseResult<UserDto>>
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly SignInManager<ApplicationUserTbl> _signInManager;
        private readonly IMapper _mapper;
        public LoginUserWebHandler(UserManager<ApplicationUserTbl> userManager, SignInManager<ApplicationUserTbl> signInManager , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }





        public async Task<ResponseResult<UserDto>> Handle(LoginUserWebCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Dto.Email);
            if (user is null)
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.BadRequest, "Error in username OR password!!");

            if (!user.IsActive)
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.BadRequest, "حساب المستخدم معطل");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Dto.Password);
            if (!isPasswordValid)
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.BadRequest, "Error in username OR password!!");

            if (!user.EmailConfirmed)
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.Forbiden, "يرجى تأكيد بريدك الإلكتروني أولاً");

            var result = await _signInManager.PasswordSignInAsync(user, request.Dto.Password, false, false);
            var dto = _mapper.Map<UserDto>(user);
            if (result.Succeeded)
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.Success, dto ,"The user logged in successfully");
            else
                return ResponseResult<UserDto>.GetResult(ResultCodeStatus.BadRequest, "The Login Operation Failed");

        }
    }
}
