using FluentValidation;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.RefreshToken
{
    public class GetAccessTokenQueryValidator:AbstractValidator<GetAccesTokenQuery>
    {
        public GetAccessTokenQueryValidator()
        {
            RuleFor(x => x.AccesToken).NotEmpty().WithMessage("AccessToken boş bırakılamaz");
            RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("RefreshToken boş bırakılamaz");
        }
    }
}
