using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace MachiKoro.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class AuthorizationServicesExtensions
{
    public static IServiceCollection AddAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthorization(
         options =>
         {
             options.AddPolicy(
                 JwtBearerDefaults.AuthenticationScheme,
                 new AuthorizationPolicyBuilder()
                     .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                     .RequireAuthenticatedUser()
                     .Build());
         });

        return services;
    }
}