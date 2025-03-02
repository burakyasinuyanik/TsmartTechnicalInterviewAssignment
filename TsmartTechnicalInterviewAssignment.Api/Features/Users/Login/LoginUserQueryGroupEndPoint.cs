using MediatR;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;
using TsmartTechnicalInterviewAssignment.Shared.Filters;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Login
{
    public static class LoginUserQueryGroupEndPoint
    {
        public static RouteGroupBuilder LoginUserQueryGroupItemEndPoint(this RouteGroupBuilder group)
        {
            group.MapPost("/Login", async (LoginUserQuery request, IMediator mediator) =>
            {
                var result = await mediator.Send(request);
                return result.ToGenericResult();
            })
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<LoginUserQuery>>();
              
            return group;
        }
    }
}
