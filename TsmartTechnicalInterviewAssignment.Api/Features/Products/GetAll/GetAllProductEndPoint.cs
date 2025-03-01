using MediatR;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetAll
{
    public static class GetAllProductEndPoint
    {
        public static RouteGroupBuilder GetAllProductGroupItemEndPoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllProductQuery());

                return result.ToGenericResult();
            })
              .MapToApiVersion(1, 0)
              .Produces(200,typeof(GetAllProductQuery));

            return group;
        }
    }
}
