using FluentValidation;

namespace MachiKoro.Application.v1.Game.Commands.AddPlayerToGame;

public class AddPlayerToGameCommandValidator : AbstractValidator<AddPlayerToGameCommand>
{
    public AddPlayerToGameCommandValidator()
    {
        RuleFor(x => x.GameId).NotEmpty();
        RuleFor(x => x.PlayerId).NotEmpty();
    }
}