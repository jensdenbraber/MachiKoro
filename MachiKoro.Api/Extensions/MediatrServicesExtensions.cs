using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MachiKoro.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class MediatrServicesExtensions
{
    public static IServiceCollection AddMediatRServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}