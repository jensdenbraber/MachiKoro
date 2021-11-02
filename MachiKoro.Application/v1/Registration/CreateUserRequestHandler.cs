using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Core.Models.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Registration
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            IdentityUser user = new()
            {
                UserName = request.UserName
            };

            bool created = await _userRepository.CreateAsync(user);

            if (!created)
            {
                return null;
            }

            return new CreateUserResponse()
            {
                UserId = user.Id
            };
        }
    }
}