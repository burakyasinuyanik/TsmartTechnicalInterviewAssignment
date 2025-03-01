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
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(AppUserRegisterDto appUserRegisterDto);
        Task<bool> ValidateUser(AppUser userForAuthenticationDto);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<AppUser> FindByEmailAsync(string email);
    }
}
