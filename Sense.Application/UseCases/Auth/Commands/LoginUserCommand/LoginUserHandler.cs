using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
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

namespace Sense.Application.UseCases.Auth.Commands.LoginUserCommand
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResponseResult<TokenDto>>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private ApplicationUserTbl? _user;
        public LoginUserHandler(IConfiguration configuration, UserManager<ApplicationUserTbl> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        private async Task<bool> ValidateUser(UserManager<ApplicationUserTbl> _userManager, UserForLoginDto dto)
        {
            _user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, dto.Password);
            return result;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:TokenKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims(UserManager<ApplicationUserTbl> _userManager)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.NameIdentifier , _user.Id) ,
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;

        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var isAdmin = claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Administrator");

            var isSystemAdmin = claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "SystemAdministrator");
            var expiration = (isAdmin || isSystemAdmin) ? DateTime.Now.AddYears(100) : DateTime.Now.AddMinutes(60);

            var tokenOptions = new JwtSecurityToken
            (
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
        public async Task<ResponseResult<TokenDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            bool validateUser = await ValidateUser(_userManager, request.Dto);
            if (validateUser)
            {
                if (!_user.IsActive)
                    return ResponseResult<TokenDto>.GetResult(ResultCodeStatus.BadRequest, "حساب المستخدم معطل");
                var signingCredentials = GetSigningCredentials();
                var claims = await GetClaims(_userManager);
                var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
                var refreshToken = GenerateRefreshToken();
                _user.RefreshToken = refreshToken;
                if (request.populateExp)
                    _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(60);
                await _userManager.UpdateAsync(_user);
                var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                var data = new TokenDto() { AccessToken = accessToken, RefreshToken = refreshToken };
                return ResponseResult<TokenDto>.GetResult(ResultCodeStatus.Success, data, "The user logged in successfully");
            }
            return ResponseResult<TokenDto>.GetResult(ResultCodeStatus.BadRequest, "The username OR password not correct");
        }
    }
}
