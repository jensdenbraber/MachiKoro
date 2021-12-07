using FluentValidation;
using MachiKoro.Core.Models.Identity;

namespace MachiKoro.Application.v1.Identity.Commands.Login
{
    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}