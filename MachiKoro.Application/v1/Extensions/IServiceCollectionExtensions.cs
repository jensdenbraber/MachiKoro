using MachiKoro.Application.v1.Game.Commands.AddPlayerToGame;
using MachiKoro.Application.v1.Game.Commands.CreateGame;
using MachiKoro.Application.v1.Game.Commands.DeleteGame;
using MachiKoro.Application.v1.Game.Commands.RemovePlayerFromGame;
using MachiKoro.Application.v1.Game.Queries.GetGame;
using MachiKoro.Application.v1.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MachiKoro.Application.v1.Extensions;

[ExcludeFromCodeCoverage]
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<Services.GamesService, Services.GamesService>();

        Assembly[] assemblies = new Assembly[]
        {
            Assembly.GetAssembly(typeof(AddPlayerToGameCommandHandler)),
            Assembly.GetAssembly(typeof(CreateGameCommandHandler)),
            Assembly.GetAssembly(typeof(DeleteGameCommandHandler)),
            Assembly.GetAssembly(typeof(RemovePlayerFromGameCommandHandler)),
            Assembly.GetAssembly(typeof(GetGameRequestHandler)),
            //Assembly.GetAssembly(typeof(GetPlayerProfileRequestHandler))
        };

        services.AddMediatR(assemblies);

        return services;
    }
}