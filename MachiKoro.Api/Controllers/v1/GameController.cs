using MachiKoro.Api.Mappers;
using MachiKoro.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MachiKoro.Api.Controllers.v1;

[ApiController]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// Creates a game in the system
    /// </summary>
    /// <response code="201">Creates a game in the system</response>
    /// <response code="400">Unable to create the game due to validation error</response>
    [HttpPost(ApiRoutes.Games.Create)]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Contracts.Game.CreateGame.CreateGameResponse), 201)]
    public async Task<IActionResult> CreateAsync([FromBody][Required] Contracts.Game.CreateGame.CreateGameRequest request)
    {
        var coreRequest = request.ToCore();

        var coreResponse = await _mediator.Send(coreRequest);

        if (coreResponse is null)
            return NotFound();

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Games.Get.Replace("{gameId}", coreResponse.GameId.ToString());
        return Created(locationUri, coreResponse.GameId);
    }

    [HttpPost("/games/{gameId}/choose")] //ApiRoutes.Games.Choose)]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Contracts.Game.Choose.ChooseResponse), 201)]
    public async Task<IActionResult> ChooseAsync([FromBody][Required] Contracts.Game.Choose.ChooseRequest chooseRequest, [FromRoute][Required] Guid gameId)
    {
        var getGameRequest = new Contracts.Game.StartGame.GetGameRequest
        {
            GameId = gameId
        };

        var coreGameRequest = getGameRequest.ToCore();// _mapper.Map<Application.v1.Game.Queries.GetGame.GetGameRequest>(getGameRequest);
        var coreChooseRequest = chooseRequest.ToCore();// _mapper.Map<Application.v1.Game.Commands.Choose.ChooseRequest>(chooseRequest);
        coreChooseRequest.GameId = coreGameRequest.GameId;

        var coreResponse = await _mediator.Send(coreChooseRequest);

        if (coreResponse is null)
            return NotFound();

        return new NoContentResult();
    }

    [HttpGet(ApiRoutes.Games.Get)]
    public async Task<IActionResult> GetAsync([FromRoute][Required] Contracts.Game.StartGame.GetGameRequest request)
    {
        var coreRequest = request.ToCore();// _mapper.Map<Application.v1.Game.Queries.GetGame.GetGameRequest>(request);

        var coreResponse = await _mediator.Send(coreRequest);

        if (coreResponse is null || coreResponse.Game is null)
            return NotFound(request.GameId);

        return Ok(coreResponse.Game);
    }

    [HttpPost(ApiRoutes.Games.AddPlayer)]
    [Consumes("application/json")]
    public async Task<IActionResult> AddPlayer([FromRoute][Required] Contracts.Game.AddPlayer.AddPlayerToGameRequest request)
    {
        var coreRequest = request.ToCore();//_mapper.Map<Application.v1.Game.Commands.AddPlayerToGame.AddPlayerToGameCommand>(request);

        var coreResponse = await _mediator.Send(coreRequest);

        if (coreResponse is null)
            return NotFound();

        if (coreResponse.GameId is null)
            return NotFound(request.GameId);

        if (coreResponse.PlayerId is null)
            return NotFound(request.PlayerId);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Games.AddPlayer.Replace("{gameId}", coreResponse.GameId.ToString());
        return Created(locationUri, coreResponse.GameId);
    }

    [HttpDelete(ApiRoutes.Games.RemovePlayer)]
    [Consumes("application/json")]
    public async Task<IActionResult> RemovePlayer([FromRoute][Required] Contracts.Game.RemovePlayer.RemovePlayerFromGameRequest request)
    {
        var coreRequest = request.ToCore();//_mapper.Map<Application.v1.Game.Commands.RemovePlayerFromGame.RemovePlayerFromGameCommand>(request);

        var coreResponse = await _mediator.Send(coreRequest);

        if (coreResponse is null)
            return NotFound(request);

        return NoContent();
    }

    [HttpDelete(ApiRoutes.Games.Delete)]
    [Consumes("application/json")]
    public async Task<IActionResult> Delete([FromRoute][Required] Contracts.Game.DeleteGame.DeleteGameRequest request)
    {
        var coreRequest = request.ToCore();//_mapper.Map<Application.v1.Game.Commands.DeleteGame.DeleteGameCommand>(request);

        var coreResponse = await _mediator.Send(coreRequest);

        if (coreResponse is null)
            return NotFound(request);

        return NoContent();
    }

    [HttpPost(ApiRoutes.Games.Get + "/start")]
    public async Task<IActionResult> Start([FromRoute][Required] Contracts.Game.StartGame.StartGameRequest request)
    {
        var coreRequest = request.ToCore();//_mapper.Map<Application.v1.Game.Commands.StartGame.StartGameRequest>(request);

        var coreResponse = await _mediator.Send(coreRequest);

        return Ok();
    }
}