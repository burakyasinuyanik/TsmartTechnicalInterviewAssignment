using MediatR;
using System.Text.RegularExpressions;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;
using TsmartTechnicalInterviewAssignment.Shared.Filters;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.RefreshToken
{
    public static class GetAccesTokenQueryGroupEndPoint
    {
        public static RouteGroupBuilder GetAccesTokenQueryGroupItemEndPoint(this RouteGroupBuilder group) {

            group.MapPost("/refresh", async (GetAccesTokenQuery request, IMediator mediator) =>
            {
                var result = await mediator.Send(request);
               return result.ToGenericResult();
            })
                .MapToApiVersion(1,0)
                .AddEndpointFilter<ValidationFilter<GetAccesTokenQuery>>();

            return group;
        }
    }
}
