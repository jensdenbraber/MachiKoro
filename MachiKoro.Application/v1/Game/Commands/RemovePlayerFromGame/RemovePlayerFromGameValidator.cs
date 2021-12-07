using FluentValidation;
using MachiKoro.Core.Models.RemovePlayerFromGame;

namespace MachiKoro.Application.v1.Game.Commands.RemovePlayerFromGame
{
    public class RemovePlayerFromGameValidator : AbstractValidator<RemovePlayerFromGameRequest>
    {
        public RemovePlayerFromGameValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
            RuleFor(x => x.PlayerId).NotEmpty();
        }
    }
}