using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;

namespace MachiKoro.Application.v1.CardEffects.Landmarks.Basic;

public class ShoppingMall : ILandmarkEffect
{
    private readonly INotifyPlayerService _playerService;

    public ShoppingMall(INotifyPlayerService playerService)
    {
        _playerService = playerService ?? throw new System.ArgumentNullException(nameof(playerService));
    }

    public async void Effect(Domain.Models.Game.Game game, Domain.Models.Player.Player player, CancellationToken cancellationToken)
    {
        //TODO increase coin reward on cup and bread cards with 1
        //
        //if (game.ActivePlayer.EstablishmentCards[0].CardIcon == CardCategory.Cup ||
        //    game.ActivePlayer.EstablishmentCards[0].CardIcon == CardCategory.Bread)
        //{
        //}
        if (game.ActivePlayer.Equals(player))
        {
            var cardCategories = new List<CardCategory> { CardCategory.Cup, CardCategory.Bread };
            var bonus = 1;

            await _playerService.SendNotificationEstablishmentsBonusAsync(cardCategories, bonus, cancellationToken);
        }
    }
}