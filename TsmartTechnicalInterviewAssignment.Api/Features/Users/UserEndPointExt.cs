using Asp.Versioning.Builder;
using TsmartTechnicalInterviewAssignment.Api.Features.Products.Create;
using TsmartTechnicalInterviewAssignment.Api.Features.Users.Create;
using TsmartTechnicalInterviewAssignment.Api.Features.Users.Login;
using TsmartTechnicalInterviewAssignment.Api.Features.Users.RefreshToken;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users
{
    public static class UserEndPointExt
    {
        public static void AddUserGroupEndPointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {

            app.MapGroup("api/v{version:apiVersion}/user")
                .WithTags("User")
                .WithApiVersionSet(apiVersionSet)
                .CreateUserCommandGroupItemEndPoint()
                .LoginUserQueryGroupItemEndPoint()
                .GetAccesTokenQueryGroupItemEndPoint();
                
                
        }
    }
}
