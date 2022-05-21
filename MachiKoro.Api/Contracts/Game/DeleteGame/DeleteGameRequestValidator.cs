using FluentValidation;

namespace MachiKoro.Api.Contracts.Game.DeleteGame;

public class DeleteGameRequestValidator : AbstractValidator<DeleteGameRequest>
{
    public DeleteGameRequestValidator()
    {
        RuleFor(x => x.GameId).NotEmpty();
    }
}