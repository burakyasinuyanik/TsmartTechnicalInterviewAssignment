using AutoMapper;
using MediatR;
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.RefreshToken
{
    public class GetAccesTokenQueryHandler(IUserService userService,IMapper mapper) : IRequestHandler<GetAccesTokenQuery, ServiceResult<TokenDto>>
    {
        public async Task<ServiceResult<TokenDto>> Handle(GetAccesTokenQuery request, CancellationToken cancellationToken)
        {
            var tokenDto = mapper.Map<TokenDto>(request);
           var newToken= await userService.RefreshToken(tokenDto);
            return ServiceResult<TokenDto>.SuccessAsOk(newToken);
        }
    }
}
