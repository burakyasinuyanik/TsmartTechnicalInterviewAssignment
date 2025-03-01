using AutoMapper;
using MediatR;
using System.Net;
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Create
{
    public class CreateUserCommandHandler(IUserService userService, IMapper mapper) : IRequestHandler<CreateUserCommand, ServiceResult<string>>
    {
        public async Task<ServiceResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var hasUser = await userService.FindByEmailAsync(request.Email);
            if (hasUser is not null)
                return ServiceResult<string>.Error("Kullanıcı mevcut", "Kayıt olmak için farklı bir email adresi kullanın.", HttpStatusCode.BadRequest);

            var appUserAsDto = mapper.Map<AppUserRegisterDto>(request);
            var identityResult = await userService.RegisterUser(appUserAsDto);
            return ServiceResult<string>.SuccessAsCreated(identityResult, $"/user/{identityResult}");
        }
    }
}
