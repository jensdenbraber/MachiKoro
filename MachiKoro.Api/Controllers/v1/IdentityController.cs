﻿using AutoMapper;
using MachiKoro.Application;
using MachiKoro.Application.v1.Exceptions;
using MachiKoro.Application.v1.Identity.Commands.Login;
using MachiKoro.Application.v1.Identity.Commands.Refresh;
using MachiKoro.Application.v1.Identity.Commands.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MachiKoro.Api.Controllers.v1;

[ApiController]
public class IdentityController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public IdentityController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost(ApiRoutes.Identity.Register)]
    [Consumes("application/json")]
    [Produces("application/json")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody][Required] Contracts.Identity.Registration.CreateUserRequest request)
    {
        var coreRequest = _mapper.Map<CreateUserRequest>(request);
        coreRequest.IpAddress = IpAddress();

        try
        {
            await _mediator.Send(coreRequest);

            return NoContent();
        }
        catch (RegisterException e)
        {
            return new BadRequestObjectResult(e.Errors);
        }
        catch (UserAlreadyExistsException e)
        {
            return new BadRequestObjectResult(e.Message);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost(ApiRoutes.Identity.Login)]
    [Consumes("application/json")]
    [Produces("application/json")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody][Required] Contracts.Identity.Login.LoginUserRequest request)
    {
        var coreRequest = _mapper.Map<LoginUserRequest>(request);
        coreRequest.IpAddress = IpAddress();

        try
        {
            var coreResponse = await _mediator.Send(coreRequest);

            if (coreResponse is null)
                return NotFound();

            var response = _mapper.Map<Contracts.Identity.Login.LoginUserResponse>(coreResponse);
            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }
        catch (LoginException e)
        {
            return new BadRequestObjectResult(e.Message);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost(ApiRoutes.Identity.Refresh)]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> Refresh([FromBody] Contracts.Identity.RefreshToken.RefreshTokenRequest request)
    {
        var coreRequest = _mapper.Map<RefreshTokenRequest>(request);

        coreRequest.IpAddress = IpAddress();

        var coreResponse = await _mediator.Send(coreRequest);

        if (coreResponse is null)
            return NotFound();

        var response = _mapper.Map<Contracts.Identity.RefreshToken.RefreshTokenResponse>(coreResponse);
        SetTokenCookie(coreResponse.RefreshToken);

        return Ok(response);
    }

    private void SetTokenCookie(string token)
    {
        // append cookie with refresh token to the http response
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", token, cookieOptions);
    }

    private string IpAddress()
    {
        // get source ip address for the current request
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}