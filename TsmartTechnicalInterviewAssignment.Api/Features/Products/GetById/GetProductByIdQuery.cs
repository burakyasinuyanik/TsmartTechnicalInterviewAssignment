using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetById
{
    public record class GetProductByIdQuery(Guid id) : IRequestByServiceResult<GetProductByIdResponse>;
}
