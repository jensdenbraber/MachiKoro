using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachiKoro.Api.Extensions
{
    public static class AutomapperServicesExtensions
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));

            return services;
        }
    }
}
