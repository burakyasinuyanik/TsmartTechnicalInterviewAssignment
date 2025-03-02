using MediatR;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetById
{
    public static class GetProductByIdGroupEndPoint
    {
        public static RouteGroupBuilder GetProductByIdGroupItemEndPoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
            {

                var result = await mediator.Send(new GetProductByIdQuery(id));

                return result.ToGenericResult();
            })
                .MapToApiVersion(1, 0)
            .RequireAuthorization(["AdminOrMusteri"]);


            return group;
        }
    }
}
