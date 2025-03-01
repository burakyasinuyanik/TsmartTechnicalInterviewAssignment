using Asp.Versioning;
using Asp.Versioning.Builder;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products
{
    public static class ProductEndPointExt
    {
        public static void AddProductGroupEndPointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {

            app.MapGroup("api/v{version:apiVersion}/product")
                .WithTags("Product")
                .WithApiVersionSet(apiVersionSet);
        }
    }
}
