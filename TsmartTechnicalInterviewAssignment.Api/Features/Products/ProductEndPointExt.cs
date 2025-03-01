using Asp.Versioning;
using Asp.Versioning.Builder;
using TsmartTechnicalInterviewAssignment.Api.Features.Products.Create;
using TsmartTechnicalInterviewAssignment.Api.Features.Products.GetAll;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products
{
    public static class ProductEndPointExt
    {
        public static void AddProductGroupEndPointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {

            app.MapGroup("api/v{version:apiVersion}/product")
                .WithTags("Product")
                .WithApiVersionSet(apiVersionSet)
                .CreateProductGroupItemEndPoint()
                .GetAllProductGroupItemEndPoint();
        }
    }
}
