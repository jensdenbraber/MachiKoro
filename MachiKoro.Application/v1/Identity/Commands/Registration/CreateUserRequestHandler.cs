using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Identity.Commands.Registration
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IIdentityService _identityService;

        public CreateUserRequestHandler(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var createUserResponse = new CreateUserResponse();

            (Models.Result result, Models.Result token, string userId) = await _identityService.CreateUserAsync(request.UserName, request.Email, request.Password);

            if (result.Succeeded)
            {
                createUserResponse.UserId = Guid.Parse(userId);
                createUserResponse.Token = token.Token;
            }
            else
            {
                createUserResponse.Errors = new List<string>(result.Errors);
            }

            return createUserResponse;
        }
    }
}