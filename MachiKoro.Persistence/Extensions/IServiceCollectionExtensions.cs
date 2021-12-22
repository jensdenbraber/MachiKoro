using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Persistence.Identity.Models.Authentication;
using MachiKoro.Persistence.Identity.Services;
using MachiKoro.Persistence.Identity.Models;
using MachiKoro.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

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
            //services.AddTransient<IPlayersRepository, PlayersRepository>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<Token, Token>();

            return services;
        }

        /// <summary>
        ///     Seed Identity data
        /// </summary>
        /// <param name="builder"></param>
        public static async Task SeedIdentityDataAsync(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await Infrastructure.Identity.Seed.ApplicationDbContextDataSeed.SeedAsync(userManager, roleManager);
            }
        }
    }
}
