using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.GetGame;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.CreateGame
{
    public class GetGameRequestHandler : IRequestHandler<GetGameRequest, GetGameResponse>
    {
        private readonly IGamesRepository _gameRepository;

        public GetGameRequestHandler(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public async Task<GetGameResponse> Handle(GetGameRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var game = await _gameRepository.GetGameAsync(request.GameId);

            return new GetGameResponse()
            {
                Game = game
            };
        }
    }
}
