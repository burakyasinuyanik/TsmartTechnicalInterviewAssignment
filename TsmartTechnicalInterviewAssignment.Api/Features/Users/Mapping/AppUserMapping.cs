using AutoMapper;
using TsmartTechnicalInterviewAssignment.Api.Features.Users.Create;
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Entities.Models;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Mapping
{
    public class AppUserMapping:Profile
    {
        public AppUserMapping()
        {
            CreateMap<CreateUserCommand, AppUserRegisterDto>();
            CreateMap<AppUserRegisterDto, AppUser>();

        }
    }
}
