using AutoMapper;
using MediatR;
using System.Net;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetById
{
    public class GetProductByIdQueryHandler(IProductService productService, IMapper mapper) : IRequestHandler<GetProductByIdQuery, ServiceResult<GetProductByIdResponse>>
    {
        public async Task<ServiceResult<GetProductByIdResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var hasProduct = await productService.GetByIdAsync(request.id);
            if (hasProduct is null)
                return ServiceResult<GetProductByIdResponse>.Error("Ürün Bulunamadı", HttpStatusCode.NotFound);

            var productAsResponse = mapper.Map<GetProductByIdResponse>(hasProduct);
                 return ServiceResult<GetProductByIdResponse>.SuccessAsOk(productAsResponse);

        }
    }
}
