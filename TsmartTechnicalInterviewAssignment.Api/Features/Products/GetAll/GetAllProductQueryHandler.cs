using AutoMapper;
using Azure;
using MediatR;
using System.Text.Json;
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetAll
{
    public class GetAllProductQueryHandler(IProductService productService, IMapper mapper) : IRequestHandler<GetAllProductQuery, ServiceResult<PagedList<Product>>>
    {
      
        public async Task<ServiceResult<PagedList<Product>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var parameters = mapper.Map<GetAllParameters>(request);
            var pagedList=await productService.GetAllAsync(parameters,cancellationToken);

            return ServiceResult<PagedList<Product>>.SuccessAsOk(pagedList);
        }
    }
}
