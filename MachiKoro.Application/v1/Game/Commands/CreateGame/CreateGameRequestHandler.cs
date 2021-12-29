using MachiKoro.Application.CardDecks;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame
{
    public class CreateGameRequestHandler : IRequestHandler<CreateGameRequest, CreateGameResponse>
    {
        private readonly IGamesRepository _gameRepository;

        public CreateGameRequestHandler(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
        {
            var player = new Domain.Models.Player.Player()
            {
                Id = Guid.NewGuid(),
                CoinAmount = 3,
                PlayerType = PlayerType.Human,
                EstablishmentCards = new List<Domain.Models.Cards.Establishments.Basic.EstablishmentBase>(),
                LandmarkCards = new List<Domain.Models.Cards.Landmarks.Basic.LandMark>()
            };

            var game = new Domain.Models.Game.Game()
            {
                Id = Guid.NewGuid(),
                MaxNumberOfPlayers = request.MaxNumberOfPlayers,
                ExpensionType = request.ExpensionType,
                Players = new CircularList<Domain.Models.Player.Player> { player },
                CardDecks = CardDeckBuilder.BuildCardDecksBasicGame()
            };

            bool created = await _gameRepository.CreateAsync(game);

            if (!created)
            {
                return null;
            }

            return new CreateGameResponse()
            {
                GameId = game.Id
            };
        }
    }
}