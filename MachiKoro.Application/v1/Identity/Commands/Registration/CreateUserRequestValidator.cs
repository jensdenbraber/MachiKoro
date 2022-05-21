using FluentValidation;
using FluentValidation.Validators;

namespace MachiKoro.Application.v1.Identity.Commands.Registration;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible).MaximumLength(50);
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
    }
}