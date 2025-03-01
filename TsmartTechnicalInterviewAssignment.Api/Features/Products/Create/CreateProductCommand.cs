using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Create
{
    public record CreateProductCommand
    (string Name,
        string Description,
        double Price,
        string Barcode,
        string ProductNo,
        int Stock):IRequestByServiceResult<CreateProductResponse>;
}
