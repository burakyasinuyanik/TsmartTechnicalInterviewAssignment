using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;
using TsmartTechnicalInterviewAssignment.Shared.Filters;

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
            })
            .AddEndpointFilter<ValidationFilter<CreateProductCommand>>()
            .MapToApiVersion(1, 0)
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            return group;
        }
    }
}
