using MachiKoro.Application.v1.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Game.Commands.DeleteGame
{
    public class DeleteGameRequestHandler : IRequestHandler<DeleteGameRequest, DeleteGameResponse>
    {
        private readonly IGamesRepository _gameRepository;

        public DeleteGameRequestHandler(IGamesRepository gameRepository)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        public async Task<DeleteGameResponse> Handle(DeleteGameRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            bool deleted = await _gameRepository.DeleteAsync(request.GameId, cancellationToken);

            if (!deleted)
            {
                return null;
            }

            return new DeleteGameResponse()
            {
                GameId = request.GameId
            };
        }
    }
}