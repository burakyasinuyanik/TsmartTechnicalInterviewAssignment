using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Update
{
    public record class UpdateProductCommand(
     Guid Id,
     string Name,
     string Description,
     double Price,
     string Barcode,
     string ProductNo,
     int Stock,
     bool IsDeleted,
     bool IsActive
        ) : IRequestByServiceResult;

}
