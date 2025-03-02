using FluentValidation;

namespace TsmartTechnicalInterviewAssignment.Api.Features.Users.Create
{
    public class CreateUserCommanValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommanValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email giriniz.").EmailAddress().WithMessage("Gerçeli bir mail adresi giriniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName giriniz");
            RuleFor(x => x.Roles).NotEmpty().WithMessage("Role giriniz");
        }
    }
}
