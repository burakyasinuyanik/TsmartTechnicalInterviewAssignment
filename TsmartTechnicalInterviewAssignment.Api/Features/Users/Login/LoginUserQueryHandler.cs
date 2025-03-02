using MediatR;
using System.Net;
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Login
{
    public class LoginUserQueryHandler(IUserService userService) : IRequestHandler<LoginUserQuery, ServiceResult<TokenDto>>
    {
        public async Task<ServiceResult<TokenDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            if (!await userService.ValidateUser(request.Email, request.Password))
                return ServiceResult<TokenDto>.Error("Kullanıcı bilgilerinizi kontrol ediniz",HttpStatusCode.BadRequest);

            var tokenDto = await userService.CreateToken(true);
            return ServiceResult<TokenDto>.SuccessAsOk(tokenDto);
        }
    }
}
