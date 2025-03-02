using FluentValidation;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Login
{
    public class LoginUserQueryValidator:AbstractValidator<LoginUserQuery>
    {
        public LoginUserQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email giriniz").EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password giriniz");
        }
    }
}
