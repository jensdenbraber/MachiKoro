using FluentValidation;

namespace MachiKoro.Application.v1.Game.Commands.DeleteGame;

public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
{
    public DeleteGameCommandValidator()
    {
        RuleFor(x => x.GameId).NotEmpty();
    }
}