using AutoMapper;
using MachiKoro.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediatR;
using MachiKoro.Api.Models.CreateGame;
using MachiKoro.Application.v1;
using MachiKoro.Api.Models.GetGame;
using MachiKoro.Core.Models.AddPlayerToGame;
using MachiKoro.Core.Models.RemovePlayerFromGame;

namespace MachiKoro.Api.Controllers.v1
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GameController(IGameService gameService, IPlayerService playerService, IMapper mapper, IMediator mediator)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Creates a game in the system
        /// </summary>
        /// <response code="201">Creates a game in the system</response>
        /// <response code="400">Unable to create the game due to validation error</response>
        [HttpPost(ApiRoutes.Games.Create)]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(CreateGameResponse), 201)]
        public async Task<IActionResult> CreateAsync([FromBody][Required] CreateGameRequest request)
        {
            var coreRequest = _mapper.Map<Core.Models.CreateGame.CreateGameRequest>(request);
            
            var coreResponse = await _mediator.Send(coreRequest);
            
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Games.Get.Replace("{gameId}", coreResponse.GameId.ToString());
            return Created(locationUri, coreResponse.GameId);
        }

        [HttpGet(ApiRoutes.Games.Get)]
        public async Task<IActionResult> GetAsync([FromRoute][Required] GetGameRequest request)
        {
            var coreRequest = _mapper.Map<Core.Models.GetGame.GetGameRequest>(request); 

            var coreResponse = await _mediator.Send(coreRequest);

            if (coreResponse == null || coreResponse.Game == null)
                return NotFound(request.GameId);

            return Ok(coreResponse.Game);
        }

        [HttpPost(ApiRoutes.Games.Start)]
        [Consumes("application/json")]
        public async Task<IActionResult> Start([FromRoute][Required] Guid gameId)
        {
            // start the game by saving it inital values to the database
            throw new NotImplementedException();
        }

        [HttpPost(ApiRoutes.Games.AddPlayer)]
        [Consumes("application/json")]
        public async Task<IActionResult> AddPlayer([FromRoute][Required] AddPlayerToGameRequest request)
        {
            var coreRequest = _mapper.Map<AddPlayerToGameRequest>(request);

            var coreResponse = await _mediator.Send(coreRequest);

            if (coreResponse == null)
                return NotFound();

            if (coreResponse.GameId == null)
                return NotFound(request.GameId);

            if (coreResponse.PlayerId == null)
                return NotFound(request.PlayerId);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Games.AddPlayer.Replace("{gameId}", coreResponse.GameId.ToString());
            return Created(locationUri, coreResponse.GameId);
        }

        [HttpDelete(ApiRoutes.Games.RemovePlayer)]
        [Consumes("application/json")]
        public async Task<IActionResult> RemovePlayer([FromRoute][Required] RemovePlayerFromGameRequest request)
        {
            var coreRequest = _mapper.Map<RemovePlayerFromGameRequest>(request);

            var coreResponse = await _mediator.Send(coreRequest);

            if (coreResponse == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete(ApiRoutes.Games.Delete)]
        [Consumes("application/json")]
        public async Task<IActionResult> Delete([FromRoute] [Required] Guid gameId)
        {
            var isDeleted = await _gameService.DeleteGameAsync(gameId);

            if (isDeleted)
                return NoContent();

            return NotFound();
        }
    }
}
