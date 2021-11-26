using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.Identity;
using MachiKoro.Core.Models.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Identity
{
    public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;

        public LoginUserRequestHandler(IUserRepository userRepository, IIdentityService identityService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            MachiKoroUser machiKoroUser = new()
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                Password = request.Password
            };

            var result = await _identityService.AuthorizeAsync(request.UserName, request.Password);

            

            //var result = await _userRepository.CreateAsync(machiKoroUser);

            var createUserResponse = new LoginUserResponse();

            if (!result.Succeeded)
            {
                createUserResponse.Errors = new List<string>();
                createUserResponse.Errors.AddRange(result.Errors);

                return createUserResponse;
            }

            createUserResponse.UserId = machiKoroUser.Id;
            return createUserResponse;
        }
    }
}