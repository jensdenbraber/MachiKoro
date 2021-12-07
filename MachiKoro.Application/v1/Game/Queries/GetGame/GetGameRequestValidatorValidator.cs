using FluentValidation;
using MachiKoro.Core.Models.GetGame;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame
{
    public class GetGameRequestValidator : AbstractValidator<GetGameRequest>
    {
        public GetGameRequestValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
        }
    }
}