using AutoMapper;
using MachiKoro.Application.v1;
using MachiKoro.Application.v1.Identity.Commands.Login;
using MachiKoro.Application.v1.Identity.Commands.Refresh;
using MachiKoro.Application.v1.Identity.Commands.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Refresh([FromBody] Contracts.Identity.RefreshToken.RefreshTokenRequest request)
        {
            var coreRequest = _mapper.Map<RefreshTokenRequest>(request);

            coreRequest.IpAddress = ipAddress();

            var coreResponse = await _mediator.Send(coreRequest);
            setTokenCookie(coreResponse.RefreshToken);

            if (coreResponse == null)
                return NotFound();

            return Ok(coreResponse);
        }

        private void setTokenCookie(string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}