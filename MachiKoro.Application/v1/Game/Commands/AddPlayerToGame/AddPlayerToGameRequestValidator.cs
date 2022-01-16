using FluentValidation;

namespace MachiKoro.Application.v1.Game.Commands.AddPlayerToGame
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