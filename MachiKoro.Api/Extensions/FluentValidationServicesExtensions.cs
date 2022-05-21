using FluentValidation;
using MachiKoro.Api.Contracts.Identity.Login;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachiKoro.Api.Extensions;

public static class FluentValidationServicesExtensions
{
    public static IServiceCollection AddFluentValidationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssemblyContaining<LoginUserRequestValidator>();

        return services;
    }
}