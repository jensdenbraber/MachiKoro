using MachiKoro.Application.CardDecks;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.CreateGame;
using MachiKoro.Core.Models.Game;
using MediatR;
using System;
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

            Core.Models.Player.Player player = new Core.Models.Player.Player()
            {
                Id = Guid.NewGuid(),
                GoldAmount = 0,
                PlayerType = Core.PlayerType.Human
            };

            var game = new Game()
            {
                Id = Guid.NewGuid(),
                MaxNumberOfPlayers = request.MaxNumberOfPlayers,
                ExpensionType = request.ExpensionType,
                Players = new System.Collections.Generic.List<Core.Models.Player.Player> { player },
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
