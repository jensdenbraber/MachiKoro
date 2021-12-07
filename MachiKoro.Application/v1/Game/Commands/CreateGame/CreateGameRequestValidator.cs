using FluentValidation;
using MachiKoro.Core.Models.CreateGame;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame
{
    public class CreateGameRequestValidator : AbstractValidator<CreateGameRequest>
    {
        public CreateGameRequestValidator()
        {
            RuleFor(x => x.MaxNumberOfPlayers).NotEmpty();
            RuleFor(x => x.ExpensionType).NotEmpty();
        }
    }
}