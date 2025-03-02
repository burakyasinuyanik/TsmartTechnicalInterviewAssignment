using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.RefreshToken
{
    public record class GetAccesTokenQuery(string AccesToken, string RefreshToken) :IRequestByServiceResult<TokenDto>;
    
}
