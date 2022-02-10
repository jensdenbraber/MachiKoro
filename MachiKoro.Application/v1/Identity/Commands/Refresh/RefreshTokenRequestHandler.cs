using MachiKoro.Application.v1.Identity.Commands.Registration;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.Identity;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace MachiKoro.Application.v1.Identity.Commands.Refresh
{
    public class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
    {
        private readonly IIdentityService _identityService;

        public RefreshTokenRequestHandler(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));
            
            var refreshTokenResponse = new RefreshTokenResponse();

            var result = await _identityService.RefreshToken(request.Token, request.IpAddress);
            
            if (result.Succeeded)
            {
                refreshTokenResponse.JwtToken = request.Token;
                refreshTokenResponse.RefreshToken = result.RefreshToken;
            }
            else
            {
                //refreshTokenResponse.Errors = new List<string>(result.Errors);
            }

            return refreshTokenResponse;
        }
    }
}