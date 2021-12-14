using MachiKoro.Application.v1.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Player.Queries.GetPlayerProfile
{
    public class GetPlayerProfileRequestHandler : IRequestHandler<GetPlayerProfileRequest, GetPlayerProfileResponse>
    {
        private readonly IPlayersRepository _playerRepository;

        public GetPlayerProfileRequestHandler(IPlayersRepository playerRepository)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
        }

        public async Task<GetPlayerProfileResponse> Handle(GetPlayerProfileRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var playerProfile = await _playerRepository.GetPlayerProfile(request.PlayerId);

            if (playerProfile == null)
            {
                return null;
            }

            return new GetPlayerProfileResponse()
            {
                PlayerProfile = playerProfile
            };
        }
    }
}
