using FluentValidation;
using System;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(x => x.PlayerId).NotNull().OnAnyFailure(x => { throw new ArgumentNullException(nameof(x)); });
        RuleFor(x => x.MaxNumberOfPlayers).NotEmpty().InclusiveBetween(2, 4);
        RuleFor(x => x.ExpensionType).NotEmpty();
    }
}