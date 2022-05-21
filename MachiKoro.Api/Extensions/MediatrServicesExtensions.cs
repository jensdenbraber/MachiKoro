using MachiKoro.Application.v1.Game.Commands.CreateGame;
using MachiKoro.Application.v1.Game.Commands.DeleteGame;
using MachiKoro.Application.v1.Game.Queries.GetGame;
using MachiKoro.Application.v1.Player.Queries.GetPlayerProfile;
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
        Assembly[] assemblies = new Assembly[]
        {
            Assembly.GetAssembly(typeof(Startup)),
            Assembly.GetAssembly(typeof(CreateGameCommandHandler)),
            Assembly.GetAssembly(typeof(GetGameRequestHandler)),
            Assembly.GetAssembly(typeof(DeleteGameCommandHandler)),
			//Assembly.GetAssembly(typeof(GetPlayerProfileRequestHandler))
		};

        services.AddMediatR(assemblies);

        return services;
    }
}