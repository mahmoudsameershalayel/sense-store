using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DomainEntities;
using Sense.Application.DTOs.AuthDTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
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

namespace Sense.Application.UseCases.Auth.Commands.RefreshTokenCommand
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, ResponseResult<TokenDto>>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private ApplicationUserTbl? _user;
        public RefreshTokenHandler(IConfiguration configuration, UserManager<ApplicationUserTbl> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:TokenKey").Value)),
                ValidateLifetime = false,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out
            securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
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
                new Claim(ClaimTypes.NameIdentifier , _user.Id),
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
        public async Task<TokenDto> CreateToken(UserManager<ApplicationUserTbl> _userManager, bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(_userManager);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;
            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            await _userManager.UpdateAsync(_user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto() { AccessToken = accessToken, RefreshToken = refreshToken };
        }
        public async Task<ResponseResult<TokenDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = GetPrincipalFromExpiredToken(request.Dto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.RefreshToken != request.Dto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new SecurityTokenException("Invalid refresh token.");
            }

            _user = user;
            var newRefreshToken = GenerateRefreshToken();
            _user.RefreshToken = newRefreshToken;
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);

            await _userManager.UpdateAsync(_user);
            var data = await CreateToken(_userManager, populateExp: false);

            return ResponseResult<TokenDto>.GetResult(ResultCodeStatus.Success, data, "The token refreshed successfully");
        }
    }
}
