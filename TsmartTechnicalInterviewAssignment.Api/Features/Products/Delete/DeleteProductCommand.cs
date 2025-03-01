using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Delete
{
    public record class DeleteProductCommand(Guid Id):IRequestByServiceResult;
    
}
