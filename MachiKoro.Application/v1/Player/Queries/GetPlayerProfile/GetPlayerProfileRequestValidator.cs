using FluentValidation;
using MachiKoro.Core.Models.GetPlayerProfile;

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
