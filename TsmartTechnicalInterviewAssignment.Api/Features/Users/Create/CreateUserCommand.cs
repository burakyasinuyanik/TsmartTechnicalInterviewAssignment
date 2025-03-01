using Microsoft.AspNetCore.Identity;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Create
{
    public record class CreateUserCommand(string UserName,string Email, string Password, ICollection<string> Roles) :IRequestByServiceResult<IdentityResult>;
    
}
