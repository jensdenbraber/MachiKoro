using FluentValidation;

namespace MachiKoro.Application.v1.Identity.Commands.Refresh;

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
        RuleFor(x => x.Token).NotEmpty();
    }
}