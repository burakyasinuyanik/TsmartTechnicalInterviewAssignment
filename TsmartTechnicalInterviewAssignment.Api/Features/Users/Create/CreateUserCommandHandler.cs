using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using TsmartTechnicalInterviewAssignment.Entities.Dtos;
using TsmartTechnicalInterviewAssignment.Entities.Models;
using TsmartTechnicalInterviewAssignment.Services.Contracts;
using TsmartTechnicalInterviewAssignment.Shared;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Create
{
    public class CreateUserCommandHandler(IUserService userService, IMapper mapper) : IRequestHandler<CreateUserCommand, ServiceResult<IdentityResult>>
    {
        public async Task<ServiceResult<IdentityResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var hasUser = await userService.FindByEmailAsync(request.Email);
            if (hasUser is not null)
                return ServiceResult<IdentityResult>.Error("Kullanıcı mevcut", "Kayıt olmak için farklı bir email adresi kullanın.", HttpStatusCode.BadRequest);

            var appUserAsDto = mapper.Map<AppUserRegisterDto>(request);
            var identityResult = await userService.RegisterUser(appUserAsDto);
            if (!identityResult.Succeeded)
            {
                var errors = new StringBuilder();
                foreach (var item in identityResult.Errors)
                    errors.Append(item.Description);
                return ServiceResult<IdentityResult>.Error(new ProblemDetails()
                {
                    Detail = errors.ToString()

                }, HttpStatusCode.BadRequest);

            }
             
            return ServiceResult<IdentityResult>.SuccessAsCreated(identityResult, $"/user/{identityResult}");
        }
    }
}
