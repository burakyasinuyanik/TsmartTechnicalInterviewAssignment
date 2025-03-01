using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Login
{
    public record class LoginUserQuery(string Email,string Password): IRequestByServiceResult<TokenDto>;
    
}
