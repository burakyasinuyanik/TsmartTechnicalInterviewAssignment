using MediatR;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Delete
{
    public class DeleteProductCommandHandler(IProductService productService) : IRequestHandler<DeleteProductCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var hasProduct = await productService.GetByIdAsync(request.Id);
            if (hasProduct is null)
                return ServiceResult.Error("Ürün bulunamadı", "Silmek istediğiniz ürün mevcut değildir.", System.Net.HttpStatusCode.NotFound);
            if(hasProduct.IsDeleted)
                return ServiceResult.Error("Ürün daha önce silinmiştir", "Silmek istediğiniz ürün daha önceden silinmiştir.", System.Net.HttpStatusCode.NotFound);

            await productService.Delete(hasProduct, cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }
    }
}
