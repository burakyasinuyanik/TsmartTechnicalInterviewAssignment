using AutoMapper;
using MediatR;
using System.Net;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Update
{
    public class UpdateCreateCommandHandler(IProductService productService,IMapper mapper) : IRequestHandler<UpdateProductCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var hasProduct=await productService.GetByIdAsync(request.Id);
            if(hasProduct is null) 
                return ServiceResult.Error("Güncellemek istediğiniz ürün bulunmamaktadır",HttpStatusCode.NotFound);

            var product = mapper.Map<Product>(hasProduct);
            await productService.Update(product,cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }
    }
}
