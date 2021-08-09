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

            var game = new Game()
            {
                GameId = Guid.NewGuid(),
                MaxNumberOfPlayers = request.MaxNumberOfPlayers,
                ExpensionType = request.ExpensionType
            };

            bool created = await _gameRepository.CreateAsync(game);

            if (!created)
            {
                return null;
            }

            return new CreateGameResponse()
            {
                GameId = game.GameId
            };
        }
    }
}
