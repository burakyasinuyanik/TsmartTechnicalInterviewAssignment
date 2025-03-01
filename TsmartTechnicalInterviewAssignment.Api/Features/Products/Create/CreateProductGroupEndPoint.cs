using MediatR;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Create
{
    public static class CreateProductGroupEndPoint
    {

        public static RouteGroupBuilder CreateProductGroupItemEndPoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateProductCommand command, IMediator mediator) =>
            {

                var result = await mediator.Send(command);

               return result.ToGenericResult();
            }).MapToApiVersion(1,0);

            return group;
        }
    }
}
