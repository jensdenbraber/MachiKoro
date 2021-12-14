using FluentValidation;

namespace MachiKoro.Api.Contracts.Game.RemovePlayer
{
    public class RemovePlayerFromGameRequestValidator : AbstractValidator<RemovePlayerFromGameRequest>
    {
        public RemovePlayerFromGameRequestValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
            RuleFor(x => x.PlayerId).NotEmpty();
        }
    }
}