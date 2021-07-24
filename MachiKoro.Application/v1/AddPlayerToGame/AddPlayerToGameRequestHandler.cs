using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.AddPlayerToGame;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.AddPlayerToGame
{
    public class AddPlayerToGameRequestHandler : IRequestHandler<AddPlayerToGameRequest, AddPlayerToGameResponse>
    {
        private readonly IGamesRepository _gameRepository;

        public AddPlayerToGameRequestHandler(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public async Task<AddPlayerToGameResponse> Handle(AddPlayerToGameRequest request, CancellationToken cancellationToken)
        {
            bool added = await _gameRepository.AddPlayerToGameAsync(request.PlayerId, request.GameId);

            if (!added)
                return null;

            return new AddPlayerToGameResponse()
            {
                GameId = request.GameId,
                PlayerId = request.PlayerId
            };
        }
    }
}