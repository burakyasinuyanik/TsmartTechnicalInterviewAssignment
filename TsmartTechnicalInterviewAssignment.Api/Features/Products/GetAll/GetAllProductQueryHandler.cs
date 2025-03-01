using AutoMapper;
using MediatR;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetAll
{
    public class GetAllProductQueryHandler(IProductService productService,IMapper mapper) : IRequestHandler<GetAllProductQuery, ServiceResult<List<GetAllProductResponse>>>
    {
        public async Task<ServiceResult<List<GetAllProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var productList=await productService.GetAllAsync(cancellationToken);

            var productListAsResponse=mapper.Map<List<GetAllProductResponse>>(productList);
            return ServiceResult<List<GetAllProductResponse>>.SuccessAsOk(productListAsResponse);
        }
    }
}
