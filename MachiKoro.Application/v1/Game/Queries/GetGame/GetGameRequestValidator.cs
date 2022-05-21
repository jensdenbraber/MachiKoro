using FluentValidation;
using MachiKoro.Application.v1.Game.Queries.GetGame;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame;

public class GetGameRequestValidator : AbstractValidator<GetGameRequest>
{
    public GetGameRequestValidator()
    {
        RuleFor(x => x.GameId).NotEmpty();
    }
}