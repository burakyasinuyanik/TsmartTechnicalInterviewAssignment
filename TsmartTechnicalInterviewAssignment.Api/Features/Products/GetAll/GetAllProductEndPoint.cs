using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TsmartTechnicalInterviewAssignment.Shared.Extensions;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetAll
{
    public static class GetAllProductEndPoint
    {
        public static RouteGroupBuilder GetAllProductGroupItemEndPoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([AsParameters] GetAllProductQuery request, IMediator mediator,IHttpContextAccessor contextAccessor) =>
            {
                var result = await mediator.Send(request);
                contextAccessor.HttpContext.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));
                return result.ToGenericResult();
            })
              .MapToApiVersion(1, 0)
              .Produces(200, typeof(GetAllProductQuery))
            .RequireAuthorization(["AdminOrMusteri"]);
            


            return group;
        }
    }
}
