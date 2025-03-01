using MediatR;
using TsmartTechnicalInterviewAssignment.Shared;


namespace TsmartTechnicalInterviewAssignment.Api.Features.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResult<GetProductByIdResponse>>
    {
        public async Task<ServiceResult<GetProductByIdResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
