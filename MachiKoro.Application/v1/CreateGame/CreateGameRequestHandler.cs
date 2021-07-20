using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core;
using MachiKoro.Core.Models.CreateGame;
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
        private readonly IMediator _mediator;

        public CreateGameRequestHandler(IGamesRepository scenarioWonenRepository, IMediator mediator)
        {
            _gameRepository = scenarioWonenRepository ?? throw new ArgumentNullException(nameof(scenarioWonenRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<CreateGameResponse> Handle(CreateGameRequest request, CancellationToken cancellationToken)
        {
            Game game = new Game(new List<Core.CardDecks.CardDeck>(), new List<Dice>())
            {
                Id = Guid.NewGuid()
            };

            await _gameRepository.CreateAsync(game);

            return new CreateGameResponse()
            {
                Id = game.Id
            };
        }
    }
}
