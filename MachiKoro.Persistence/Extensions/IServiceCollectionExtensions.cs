using MachiKoro.Persistence.Identity.Models.Authentication;
using MachiKoro.Persistence.Identity.Services;
using MachiKoro.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using MachiKoro.Persistence.Data;
using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Persistence.Extensions;

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
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MachiKoro;Trusted_Connection=True;MultipleActiveResultSets=true"));
        services.AddDbContext<IdentityDataContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString(ConnectionString)));

        services.AddTransient<IGamesRepository, GamesRepository>();
        services.AddTransient<IStepsRepository, StepsRepository>();

        //services.AddTransient<IPlayersRepository, PlayersRepository>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<Token, Token>();

        return services;
    }
}