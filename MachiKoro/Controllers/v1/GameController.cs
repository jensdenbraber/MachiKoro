using AutoMapper;
using MachiKoro.Contracts.v1;
using MachiKoro.Contracts.v1.Requests;
using MachiKoro.Contracts.v1.Responses;
using MachiKoro.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MachiKoro.Api.Models;
using MachiKoro.Api.Exceptions;
using System.ComponentModel.DataAnnotations;
using MediatR;
using MachiKoro.Api.Models.CreateGame;

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
        [ProducesResponseType(typeof(GameResponse), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> CreateAsync([FromBody][Required] CreateGameRequest request)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new GameFailedResponse
            //    {
            //        Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
            //    });
            //}

            //var game = new Game()
            //{
            //    Id = Guid.NewGuid(),
            //    MaxNumberOfPlayers = request.MaxNumberOfPlayers
            //};


            var coreRequest = _mapper.Map<Core.Models.CreateGame.CreateGameRequest>(request);
            
            var coreResponse = await _mediator.Send(coreRequest);

            //if (coreResponse.State.Status != Core.Model.RequestStatus.OK)
            //{
            //    throw new InvalidOperationException($"the request state is {coreResponse.State.Status}",
            //        coreResponse.State.Exception);
            //}

            //var apiResponse = new CreateScenarioWonenResponse
            //{
            //    State = coreResponse.State.Status.ToString(),
            //    Id = _mapper.Map<Guid>(coreResponse.Id)
            //};

            //return Ok(apiResponse);


            throw new NotImplementedException();


            //var created = await _gameService.CreateAsync(game);

            //if (!created)
            //    return BadRequest(new ErrorResponse(new ErrorModel { Message = "Unable to create game" }));
            
            //var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var locationUri = baseUrl + "/" + ApiRoutes.Games.Get.Replace("{gameId}", game.Id.ToString());
            //return Created(locationUri, _mapper.Map<GameResponse>(game));
        }

        [HttpGet(ApiRoutes.Games.Get)]
        public async Task<IActionResult> GetAsync([FromRoute][Required] Guid gameId)
        {
            var game = await _gameService.GetGameByIdAsync(gameId);

            

            //var coreResponse = await _mediator.Send(coreRequest);

            if (game == null)
                return NotFound(gameId);

            return Ok(_mapper.Map<GameResponse>(game));
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
        public async Task<IActionResult> AddPlayer([FromRoute][Required] Guid gameId, [FromBody][Required] PlayerResponse playerResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new GameFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var game = await _gameService.GetGameByIdAsync(gameId);

            if (game == null)
                return NotFound(gameId);

            var player = await _playerService.GetPlayerByIdAsync(playerResponse.Id);

            if (player == null)
                return NotFound(playerResponse);

            var isPlayerAdded = await _gameService.AddPlayerAsync(gameId, player);

            if (!isPlayerAdded)
                return BadRequest(new ErrorResponse(new ErrorModel { Message = $"Unable to add the player: {player}" }));

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Games.AddPlayer.Replace("{gameId}", game.Id.ToString());
            return Created(locationUri, _mapper.Map<GameResponse>(game));
        }

        [HttpDelete(ApiRoutes.Games.RemovePlayer)]
        public async Task<IActionResult> RemovePlayer([FromRoute] [Required] Guid gameId, [FromRoute] [Required] Guid playerId)
        {
            bool isRemoved = await _gameService.RemovePlayerAsync(gameId, playerId);

            if(!isRemoved)
                return BadRequest(new ErrorResponse(new ErrorModel { Message = $"Unable to remove the player with id: {playerId}" }));

            return Ok(playerId);
        }

        [HttpDelete(ApiRoutes.Games.Delete)]
        public async Task<IActionResult> Delete([FromRoute] [Required] Guid gameId)
        {
            var isDeleted = await _gameService.DeleteGameAsync(gameId);

            if (isDeleted)
                return NoContent();

            return NotFound();
        }
    }
}
