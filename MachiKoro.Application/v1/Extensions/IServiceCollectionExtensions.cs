using MachiKoro.Application.v1.Game.Commands.AddPlayerToGame;
using MachiKoro.Application.v1.Game.Commands.CreateGame;
using MachiKoro.Application.v1.Game.Commands.DeleteGame;
using MachiKoro.Application.v1.Game.Commands.RemovePlayerFromGame;
using MachiKoro.Application.v1.Game.Queries.GetGame;
using MachiKoro.Application.v1.Services;
using MachiKoro.Domain.Interfaces;
using MachiKoro.Domain.Models.CardDecks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MachiKoro.Application.v1.Extensions;

[ExcludeFromCodeCoverage]
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<GamesService, GamesService>();
        services.AddTransient<List<CardDeck>, List<CardDeck>>();
        services.AddTransient<ICardDeckService, CardDeckService>();
        services.AddTransient<ICardDeckBuilderService, CardDeckBuilderService>();

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