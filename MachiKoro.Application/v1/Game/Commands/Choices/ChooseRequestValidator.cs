using FluentValidation;

namespace MachiKoro.Application.v1.Game.Commands.Choose;

public class ChooseRequestValidator : AbstractValidator<ChooseRequest>
{
    public ChooseRequestValidator()
    {
        RuleFor(x => x.Index).NotEmpty();
    }
}