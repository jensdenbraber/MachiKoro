using FluentValidation;

namespace MachiKoro.Api.Contracts.Game.AddPlayer
{
    public class AddPlayerToGameRequestValidator : AbstractValidator<AddPlayerToGameRequest>
    {
        public AddPlayerToGameRequestValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
            RuleFor(x => x.PlayerId).NotEmpty();
        }
    }
}