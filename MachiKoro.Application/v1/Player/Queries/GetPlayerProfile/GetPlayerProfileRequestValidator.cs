using FluentValidation;

namespace MachiKoro.Application.v1.Player.Queries.GetPlayerProfile
{
    public class GetPlayerProfileRequestValidator : AbstractValidator<GetPlayerProfileRequest>
    {
        public GetPlayerProfileRequestValidator()
        {
            RuleFor(x => x.PlayerId).NotEmpty();
        }
    }
}
