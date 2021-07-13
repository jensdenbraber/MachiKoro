using MachiKoro.Data;
using MachiKoro.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachiKoro.Api.Installers
{
    public class DbInstaller : IInstaller
    {
        private const string ConnectionString = "DefaultConnection";

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
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

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityDataContext>();

            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IPlayersRepository, PlayersRepository>();
        }
    }
}
