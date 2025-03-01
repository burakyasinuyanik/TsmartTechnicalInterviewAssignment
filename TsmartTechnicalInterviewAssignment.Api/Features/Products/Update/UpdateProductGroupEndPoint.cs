using MediatR;
using Refit;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;
using TsmartTechnicalInterviewAssignment.Shared.Filters;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Update
{
    public static class UpdateProductGroupEndPoint
    {
        public static RouteGroupBuilder UpdateProductGroupItemEndPoint(this RouteGroupBuilder group)
        {
            group.MapPut("/", async (UpdateProductCommand request, IMediator mediator) =>
            {
                var result= await mediator.Send(request);

                return result.ToGenericResult();
            })
                .MapToApiVersion(1,0)
                .AddEndpointFilter<ValidationFilter<UpdateProductCommand>>()
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            return group;
        }
    }
}
