using MachiKoro.Contracts.v1.Requests;
using MachiKoro.Contracts.v1.Responses;
using MachiKoro.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Game game = new Game()
            {
                Id = Guid.NewGuid()
            }

            await _gameRepository.CreateAsync(game);

            //request.CreatedScenarioId = scenarioWonen.Id;

            //if (request. HuidigeSituatieId != Guid.Empty) //TODO: moet required worden gezet zodra de frontend daarvoor klaar is.
            //{
            //    await _mediator.Publish(new ScenarioCreatedNotification(scenarioWonen, request.HuidigeSituatieId.Value));
            //}

            return new CreateGameResponse()
            {
                Id = game.Id
            };
        }
    }
}
