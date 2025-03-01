using MediatR;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Create
{
    public static class CreateUserCommandGroupEndPoint
    {
        public static RouteGroupBuilder CreateUserCommandGroupItemEndPoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateUserCommand request, IMediator mediator) =>
            {
                var result = await mediator.Send(request);

                return result.ToGenericResult();
            })
                .MapToApiVersion(1,0);
            return group;
        }
    }
}
