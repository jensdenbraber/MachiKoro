using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace MachiKoro.Persistence.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGamesRepository, GamesRepository>();
            services.AddTransient<IPlayersRepository, PlayersRepository>();
            return services;
        }
    }
}
