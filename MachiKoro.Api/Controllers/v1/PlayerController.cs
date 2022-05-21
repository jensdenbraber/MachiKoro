using AutoMapper;
using MachiKoro.Api.Contracts.Player.GetPlayerProfile;
using MachiKoro.Application.v1;
using MachiKoro.Application.v1.Game.Commands.CreateGame;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MachiKoro.Api.Controllers.v1;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class PlayerController : ControllerBase
{
    //private readonly IMapper _mapper;
    //private readonly IMediator _mediator;

    //public PlayerController(IMapper mapper, IMediator mediator)
    //{
    //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    //    _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    //}

    //[HttpPost(ApiRoutes.Players.Create)]
    //[Consumes("application/json")]
    //public async Task<IActionResult> CreateAsync([FromRoute][Required] CreatePlayerRequest request)
    //{
    //    var coreRequest = _mapper.Map<CreateGameRequest>(request);

    //    var coreResponse = await _mediator.Send(coreRequest);

    //    if (coreResponse == null)
    //        return NotFound();

    //    return Ok();
    //}

    //[HttpGet(ApiRoutes.Players.GetProfile)]
    //public async Task<IActionResult> Profile([FromRoute][Required] GetPlayerProfileRequest request)
    //{
    //    var coreRequest = _mapper.Map<Application.v1.Player.Queries.GetPlayerProfile.GetPlayerProfileRequest>(request);

    //    var coreResponse = await _mediator.Send(coreRequest);

    //    if (coreResponse == null)
    //        return NotFound(request.PlayerId);

    //    return Ok(coreResponse);
    //}
}