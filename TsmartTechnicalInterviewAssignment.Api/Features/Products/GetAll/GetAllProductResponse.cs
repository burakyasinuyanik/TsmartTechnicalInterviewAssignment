namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetAll
{
    public record class GetAllProductResponse
    (
     Guid Id,
     string Name,
     string Description,
     bool IsDeleted,
     bool IsActive,
     DateTime DateCraeted,
     DateTime DateModified,
     double Price,
     string Barcode,
     string ProductNo,
     int Stock
        );
}
