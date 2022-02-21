using MachiKoro.Application.v1.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Identity.Commands.Registration
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, Unit>
    {
        private readonly IIdentityService _identityService;

        public CreateUserRequestHandler(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<Unit> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            await _identityService.CreateUserAsync(request.UserName, request.Email, request.Password, request.IpAddress);

            return Unit.Value;
        }
    }
}