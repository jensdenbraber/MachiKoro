using MachiKoro.Application.v1.Models;
using MachiKoro.Infrastructure.Identity.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace MachiKoro.Persistence.Identity.Extensions
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }

        public static Result ToApplicationResult(this TokenResponse tokenResponse)
        {
            var result = Result.Success();
            result.Token = tokenResponse.Token;

            return result;
        }
    }
}