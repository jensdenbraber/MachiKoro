using FluentValidation;

namespace MachiKoro.Api.Contracts.Identity.RefreshToken
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}
