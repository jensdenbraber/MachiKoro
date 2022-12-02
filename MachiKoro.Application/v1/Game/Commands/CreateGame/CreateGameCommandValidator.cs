using FluentValidation;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(x => x.PlayerId).NotNull();
        RuleFor(x => x.MaxNumberOfPlayers).NotEmpty().InclusiveBetween(2, 4);
        RuleFor(x => x.ExpensionType).NotEmpty();
    }
}