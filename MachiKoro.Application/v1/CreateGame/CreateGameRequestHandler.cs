using MachiKoro.Application.CardDecks;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.CreateGame;
using MachiKoro.Core.Models.Game;
using MachiKoro.Core.Models.Player;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.CreateGame
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
            request = request ?? throw new ArgumentNullException(nameof(request));

            Player player = new()
            {
                Id = Guid.NewGuid(),
                GoldAmount = 0,
                PlayerType = Core.PlayerType.Human
            };

            Game game = new()
            {
                Id = Guid.NewGuid(),
                MaxNumberOfPlayers = request.MaxNumberOfPlayers,
                ExpensionType = request.ExpensionType,
                Players = new List<Player> { player },
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
