﻿using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.GetPlayerProfile;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.CreateGame
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
                       
            return new GetPlayerProfileResponse()
            {
                PlayerProfile = playerProfile
            };
        }
    }
}