using FluentValidation;

namespace MachiKoro.Api.Contracts.Game.GetGame
{
    public class GetGameRequestValidator : AbstractValidator<GetGameRequest>
    {
        public GetGameRequestValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
        }
    }
}