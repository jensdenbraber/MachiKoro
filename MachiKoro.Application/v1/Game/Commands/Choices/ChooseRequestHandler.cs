﻿using MachiKoro.Application.v1.Dice;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Game.Commands.Choose;

public class ChooseRequestHandler : IRequestHandler<ChooseRequest, ChooseResponse>
{
    private readonly IGamesRepository _gameRepository;
    private readonly Services.GamesService _gamesService;

    public ChooseRequestHandler(IGamesRepository gameRepository, Services.GamesService gamesService)
    {
        _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        _gamesService = gamesService ?? throw new ArgumentNullException(nameof(gamesService));
    }

    public async Task<ChooseResponse> Handle(ChooseRequest request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameAsync(request.GameId, cancellationToken);

        if (game.ActivePlayer.Id != request.PlayerId)
        {
            throw new UnauthorizedAccessException();
        }

        if (request.Index > game.Step.Options.Count)
        {
            throw new ArgumentOutOfRangeException("Chosen option is out of bounds.");
        }

        var chosenOption = game.Step.Options[request.Index];

        switch (game.Step.ChoiceType)
        {
            //case ChoiceType.AmountDices:
            //    await _gamesService.PostActionDiceAmountAsync(game, chosenOption, cancellationToken);
            //    break;

            //case ChoiceType.ConstructEstablishment:
            //    await _gamesService.PostActionConstructionEstablishmentAsync(game, chosenOption, cancellationToken);

            //    break;

            //case ChoiceType.ConstructLandmark:
            //    await _gamesService.PostActionConstructionLandmarkAsync(game, chosenOption, cancellationToken);
            //    break;

            default:
                break;
        }

        return new ChooseResponse();
    }
}