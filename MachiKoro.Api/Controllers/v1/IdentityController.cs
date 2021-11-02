﻿using MachiKoro.Contracts.v1.Requests;
using MachiKoro.Contracts.v1.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using MachiKoro.Application.v1;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;

namespace MachiKoro.Api.Controllers.v1
{
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
        public async Task<IActionResult> Register([FromBody][Required] UserRegistrationRequest request)
        {
            var coreRequest = _mapper.Map<Core.Models.CreateUser.CreateUserRequest>(request);

            var coreResponse = await _mediator.Send(coreRequest);

            if (coreResponse == null)
                return NotFound();


            //var authResponse = await _identityService.RegisterAsync(request.UserName, request.Email, request.Password);

            //if (!authResponse.Success)
            //{
            //    return BadRequest(new AuthFailedResponse
            //    {
            //        Errors = authResponse.Errors
            //    });
            //}

            //return Ok(new AuthSuccessResponse
            //{
            //    Token = authResponse.Token,
            //    RefreshToken = authResponse.RefreshToken
            //});

            return Ok();
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody][Required] UserLoginRequest request)
        {
            var coreRequest = _mapper.Map<Core.Models.CreateGame.CreateGameRequest>(request);

            var coreResponse = await _mediator.Send(coreRequest);

            if (coreResponse == null)
                return NotFound();

            //return Ok(new AuthSuccessResponse
            //{
            //    Token = authResponse.Token,
            //    RefreshToken = authResponse.RefreshToken
            //});

            return Ok();
        }

        [HttpPost(ApiRoutes.Identity.Refresh)]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        {
            //var authResponse = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);

            //if (!authResponse.Success)
            //{
            //    return BadRequest(new AuthFailedResponse
            //    {
            //        Errors = authResponse.Errors
            //    });
            //}

            //return Ok(new AuthSuccessResponse
            //{
            //    Token = authResponse.Token,
            //    RefreshToken = authResponse.RefreshToken
            //});

            return Ok();
        }
    }
}