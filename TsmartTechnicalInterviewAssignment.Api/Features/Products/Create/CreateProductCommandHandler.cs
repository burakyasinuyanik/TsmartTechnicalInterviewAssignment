using AutoMapper;
using MassTransit;
using MediatR;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Create
{
    public class CreateProductCommandHandler(IProductService productService,IMapper mapper) : IRequestHandler<CreateProductCommand, ServiceResult<CreateProductResponse>>
    {
        public async Task<ServiceResult<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var productAsRequest= mapper.Map<Product>(request);
            productAsRequest.Id=NewId.NextSequentialGuid();
            productAsRequest.DateCraeted=DateTime.Now;
            productAsRequest.DateModified=DateTime.Now;
            
            await productService.CreateProduct(productAsRequest);

            return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(productAsRequest.Id), "empty");
            
        }
    }
}
