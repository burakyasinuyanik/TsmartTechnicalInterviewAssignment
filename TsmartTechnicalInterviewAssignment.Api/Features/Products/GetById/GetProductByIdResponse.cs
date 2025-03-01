namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetById
{
    public record  class GetProductByIdResponse(
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
     int Stock);

}
