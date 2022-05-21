using FluentValidation;

namespace MachiKoro.Api.Contracts.Player.GetPlayerProfile;

public class GetPlayerProfileRequestValidator : AbstractValidator<GetPlayerProfileRequest>
{
    public GetPlayerProfileRequestValidator()
    {
        RuleFor(x => x.PlayerId).NotEmpty();
    }
}