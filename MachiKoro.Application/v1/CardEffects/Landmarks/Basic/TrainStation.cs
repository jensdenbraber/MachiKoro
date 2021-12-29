using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Landmarks.Basic
{
    public class TrainStation : ILandmarkEffect
    {
        public void Effect(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            //TODO able to throw with 2 dice
            if (game.ActivePlayer.Equals(player))
            {
            }
        }
    }
}