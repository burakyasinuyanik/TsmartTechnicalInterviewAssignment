using MediatR;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Delete
{
    public static class DeleteProductByIdGroupEndPoint
    {
        public static RouteGroupBuilder DeleteProductByIdGroupItemEndPoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
            {
                var result = await mediator.Send(new DeleteProductCommand(id));
               return result.ToGenericResult();
            })
                .MapToApiVersion(1, 0); ;


            return group;
        }
    }
}
