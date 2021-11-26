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
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;

        public CreateUserRequestHandler(IUserRepository userRepository, IIdentityService identityService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var createUserResponse = new CreateUserResponse();

            (Models.Result Result, Models.Result token, string UserId) p = await _identityService.CreateUserAsync(request.UserName, request.Email, request.Password);
            
            if(p.Result.Succeeded)
            {
                createUserResponse.UserId = Guid.Parse(p.UserId);
            }
            else
            {
                createUserResponse.Errors.AddRange(p.Result.Errors);
            }
               
            return createUserResponse;

            //var result = await _userRepository.CreateAsync(machiKoroUser);

            //if (!result.Succeeded)
            //{
            //    createUserResponse.Errors = new List<IdentityError>();
            //    createUserResponse.Errors.AddRange(result.Errors);

            //    return createUserResponse;
            //}

            //createUserResponse.UserId = machiKoroUser.Id;
            //return createUserResponse;
        }
    }
}