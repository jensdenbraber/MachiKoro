using AutoMapper;
using MachiKoro.Api.Models.GetPlayerProfile;
using MachiKoro.Api.Services;
using MachiKoro.Application.v1;
using MachiKoro.Contracts.v1.Requests;
using MachiKoro.Core.Models.Game;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MachiKoro.Api.Controllers.v1
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PlayerController(IPlayerService playerService, IMapper mapper, IMediator mediator)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(ApiRoutes.Players.Create)]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateAsync([FromRoute][Required] CreatePlayerRequest request)
        {
            var coreRequest = _mapper.Map<Core.Models.CreateGame.CreateGameRequest>(request);

            var coreResponse = await _mediator.Send(coreRequest);


            //var created = await _playerService.CreatePlayerAsync(player); 

            //if (!created)
            //{
            //    return BadRequest(new ErrorResponse(new ErrorModel { Message = "Unable to create Player" }));
            //}

            //var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var locationUri = baseUrl + "/" + ApiRoutes.Players.Get.Replace("{playerId}", player.Id.ToString());
            //return Created(locationUri, _mapper.Map<PlayerResponse>(player));
            return Ok();
        }


        //[HttpGet(ApiRoutes.Players.Get)]
        //public async Task<IActionResult> Get([FromRoute] GetPlayerRequest request)
        //{
        //    var coreRequest = _mapper.Map<Core.Models. GetGame.GetGameRequest>(request);

        //    var coreResponse = _mediator.Send(coreRequest);

        //    var player = await _playerService.GetPlayerByIdAsync(playerId);

        //    if(player == null)
        //        return NotFound();

        //    return Ok(_mapper.Map<PlayerResponse>(player));
        //}

        [HttpGet(ApiRoutes.Players.GetProfile)]
        public async Task<IActionResult> Profile([FromRoute][Required] GetPlayerProfileRequest request)
        {
            var coreRequest = _mapper.Map<Core.Models.GetPlayerProfile.GetPlayerProfileRequest>(request);

            var coreResponse = await _playerService.GetPlayerProfileAsync(coreRequest.PlayerId);

            if (coreResponse == null)
                return NotFound(request.PlayerId);

            return Ok(coreResponse);
        }

        [HttpGet(ApiRoutes.Players.GetGame)]
        public async Task<IActionResult> Game([FromRoute] Guid playerId, [FromRoute] Guid gameId)
        {
            var player = await _playerService.GetPlayerByIdAsync(playerId);
            if (player == null)
                return NotFound(playerId);

            var game = await _playerService.GetGameAsync(playerId, gameId);
            if(game == null)
                return NotFound(gameId);

            return Ok(_mapper.Map<Game>(game));
        }

        [HttpGet(ApiRoutes.Players.GetGames)]
        public async Task<IActionResult> Games([FromRoute] Guid playerId)
        {
            var player = await _playerService.GetPlayerByIdAsync(playerId);
            if (player == null)
                return NotFound(playerId);

            var games = await _playerService.GetGamesAsync(playerId);

            return Ok(_mapper.Map<List<Game>>(games));
        }

        [HttpPut(ApiRoutes.Players.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid playerId, [FromBody] UpdatePlayerRequest userRequest)
        {


            var player = await _playerService.GetPlayerByIdAsync(playerId);

            if (player == null)
                return NotFound();

            //player.UserName = userRequest.UserName;

            var isUpdated = await _playerService.UpdatePlayerAsync(player);
            if (isUpdated)
                return NoContent();

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Players.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid playerId)
        {
            var isDeleted = await _playerService.DeletePlayerAsync(playerId);

            if (isDeleted)
                return NoContent();

            return NotFound();
        }
    }
}
