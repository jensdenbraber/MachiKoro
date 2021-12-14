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

            MachiKoroUser machiKoroUser = new()
            {
                UserName = request.UserName,
                Password = request.Password
            };

            var result = await _identityService.AuthorizeAsync(request.UserName, request.Password);

            var createUserResponse = new LoginUserResponse();

            if (!result.Succeeded)
            {
                createUserResponse.Errors = new List<string>();
                createUserResponse.Errors.AddRange(result.Errors);

                return createUserResponse;
            }

            createUserResponse.UserId = machiKoroUser.Id;
            createUserResponse.Token = result.Token;

            return createUserResponse;
        }
    }
}