using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MachiKoro.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class AutomapperServicesExtensions
{
    public static IServiceCollection AddAutoMapperServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(Startup));

        services.AddControllers()
   .AddJsonOptions(x =>
   {
       x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
   });

        return services;
    }
}