using FluentValidation;
using MachiKoro.Core.Models.DeleteGame;

namespace MachiKoro.Application.v1.Game.Commands.DeleteGame
{
    public class DeleteGameRequestValidator : AbstractValidator<DeleteGameRequest>
    {

        public DeleteGameRequestValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
        }
    }
}
