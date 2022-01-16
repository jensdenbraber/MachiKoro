using FluentValidation;

namespace MachiKoro.Application.v1.Game.Commands.RemovePlayerFromGame
{
    public class RemovePlayerFromGameRequestValidator : AbstractValidator<RemovePlayerFromGameRequest>
    {
        public RemovePlayerFromGameRequestValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
            RuleFor(x => x.PlayerId).NotEmpty();
        }
    }
}