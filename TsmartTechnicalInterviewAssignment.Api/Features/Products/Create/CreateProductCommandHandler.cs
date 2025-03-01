using AutoMapper;
using MassTransit;
using MediatR;
using System.Net;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.Create
{
    public class CreateProductCommandHandler(IProductService productService, IMapper mapper) : IRequestHandler<CreateProductCommand, ServiceResult<CreateProductResponse>>
    {
        public async Task<ServiceResult<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var existProduct = await productService.FindByConditionOne(x => x.Name == request.Name,cancellationToken);
            if (existProduct is not null)
                return ServiceResult<CreateProductResponse>.Error("İlgili ürün mevcut", $"{request.Name} daha önce kayıtlı bir üründür.", HttpStatusCode.BadRequest);
            var product = mapper.Map<Product>(request);
            product.Id = NewId.NextSequentialGuid();
            product.DateCraeted = DateTime.Now;
            product.DateModified = DateTime.Now;
            await productService.Create(product,cancellationToken);
            return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id), $"/products/{product.Id}");


        }
    }
}
