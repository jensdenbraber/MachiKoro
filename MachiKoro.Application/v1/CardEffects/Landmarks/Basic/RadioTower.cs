using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Landmarks.Basic
{
    public class RadioTower : ILandmarkEffect
    {
        public void Effect(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            //TODO choose if you want to reroll the dice for this turn

            if (game.ActivePlayer.Equals(player))
            {
                // TODO send to GameHub for client to chose for reroll
            }
        }
    }
}