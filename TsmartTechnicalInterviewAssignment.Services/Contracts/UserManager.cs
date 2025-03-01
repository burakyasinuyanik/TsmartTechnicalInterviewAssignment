using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Services.Contracts
{
    public class UserManager(UserManager<AppUser> userManager,IMapper mapper) : IUserService
    {
        private AppUser _appUser;
        public Task<TokenDto> CreateToken(bool populateExp)
        {
          
            throw new NotImplementedException();
        }

        public async Task<AppUser> FindByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUser(AppUserRegisterDto appUserRegisterDto)
        {
            var user = mapper.Map<AppUser>(appUserRegisterDto);
            var result=await userManager.CreateAsync(user,appUserRegisterDto.Password);
            if (result.Succeeded)
                await userManager.AddToRolesAsync(user,appUserRegisterDto.Roles);
          
            return result;
        }

        public async Task<bool> ValidateUser(string email,string password)
        {
            _appUser = await userManager.FindByEmailAsync(email);
            var result = (_appUser is not null && await userManager.CheckPasswordAsync(_appUser, password));
            
            return result;
        }
    }
}
