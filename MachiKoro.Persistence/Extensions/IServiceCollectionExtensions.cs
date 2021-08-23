using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace MachiKoro.Persistence.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        private const string ConnectionString = "DefaultConnection";

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlayerDataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(ConnectionString)));
            services.AddDbContext<GameDataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(ConnectionString)));
            services.AddDbContext<IdentityDataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(ConnectionString)));

            services.AddTransient<IGamesRepository, GamesRepository>();
            services.AddTransient<IPlayersRepository, PlayersRepository>();

            return services;
        }
    }
}
