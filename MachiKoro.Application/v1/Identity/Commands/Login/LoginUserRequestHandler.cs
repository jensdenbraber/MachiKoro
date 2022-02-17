using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Identity.Commands.Login
{
    public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IIdentityService _identityService;

        public LoginUserRequestHandler(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var result = await _identityService.AuthorizeAsync(request.UserName, request.Password, request.IpAddress);

            var createUserResponse = new LoginUserResponse();

            if (!result.Result.Succeeded)
            {
                createUserResponse.Errors = new List<string>();
                createUserResponse.Errors.AddRange(result.Result.Errors);

                return createUserResponse;
            }

            createUserResponse.UserId = new Guid(result.UserId);
            createUserResponse.Token = result.Result.Token;

            return createUserResponse;
        }
    }
}