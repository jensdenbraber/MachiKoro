using FluentValidation;

namespace MachiKoro.Api.Contracts.Game.CreateGame
{
    public class CreateGameRequestValidator : AbstractValidator<CreateGameRequest>
    {
        public CreateGameRequestValidator()
        {
            RuleFor(x => x.MaxNumberOfPlayers).NotEmpty().InclusiveBetween(2, 4);
            RuleFor(x => x.ExpensionType).NotEmpty();
        }
    }
}