using AutoMapper;
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
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Services.Contracts
{
    public class UserManager(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration) : IUserService
    {
        private AppUser _appUser;
        public async Task<TokenDto> CreateToken(bool populateExp)
        {

            var signinCredentials = GetSiginCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);
            var refreshToken = GenerateRefreshToken();
            _appUser.RefreshToken = refreshToken;
            if (populateExp)
                _appUser.RefreshTokenExpiryToken = DateTime.Now.AddMinutes(30);
            await userManager.UpdateAsync(_appUser);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto(accessToken, refreshToken);
            
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

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signinCredentials
                );

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,_appUser.Email)
            };
            var roles = await userManager.GetRolesAsync(_appUser);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSiginCredentials()
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<AppUser> FindByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccesToken);
            var user = await userManager.FindByEmailAsync(principal.FindFirstValue(ClaimTypes.Email));
            if (user is null ||
                user.RefreshToken != tokenDto.RefreshToken ||
                user.RefreshTokenExpiryToken <= DateTime.Now)
                throw new SecurityTokenException("Geçersiz token");


            _appUser = user;
            return await CreateToken(populateExp: false);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = jwtSettings["secretKey"];


            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken is null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Geçersiz token");
            }
            return principal;
        }

        public async Task<IdentityResult> RegisterUser(AppUserRegisterDto appUserRegisterDto)
        {
            var user = mapper.Map<AppUser>(appUserRegisterDto);
            var result = await userManager.CreateAsync(user, appUserRegisterDto.Password);
            if (result.Succeeded)
                await userManager.AddToRolesAsync(user, appUserRegisterDto.Roles);

            return result;
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            _appUser = await userManager.FindByEmailAsync(email);
            var result = (_appUser is not null && await userManager.CheckPasswordAsync(_appUser, password));

            return result;
        }
    }
}
