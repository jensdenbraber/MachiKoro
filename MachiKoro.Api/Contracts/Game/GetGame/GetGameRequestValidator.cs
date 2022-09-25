﻿using FluentValidation;
using MachiKoro.Api.Contracts.Game.StartGame;

namespace MachiKoro.Api.Contracts.Game.StartGame;

public class GetGameRequestValidator : AbstractValidator<StartGameRequest>
{
    public GetGameRequestValidator()
    {
        RuleFor(x => x.GameId).NotEmpty();
    }
}