using AutoMapper;
using MachiKoro.Application.v1;
using MachiKoro.Application.v1.Identity.Commands.Login;
using MachiKoro.Application.v1.Identity.Commands.Refresh;
using MachiKoro.Application.v1.Identity.Commands.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Register([FromBody][Required] CreateUserRequest request)
        {
            var coreRequest = _mapper.Map<CreateUserRequest>(request);

            var coreResponse = await _mediator.Send(coreRequest);

            if (coreResponse.Errors?.Any() ?? false)
                return BadRequest(coreResponse.Errors);

            return Ok(coreResponse);
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody][Required] LoginUserRequest request)
        {
            var coreRequest = _mapper.Map<LoginUserRequest>(request);

            var coreResponse = await _mediator.Send(coreRequest);

            if (coreResponse == null)
                return NotFound();

            //return Ok(new AuthSuccessResponse
            //{
            //    Token = authResponse.Token,
            //    RefreshToken = authResponse.RefreshToken
            //});

            return Ok(coreResponse);
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