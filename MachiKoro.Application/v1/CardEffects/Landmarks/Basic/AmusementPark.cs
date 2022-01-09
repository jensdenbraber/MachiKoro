using MachiKoro.Application.v1.Dice;
using MachiKoro.Domain.Interfaces;

namespace MachiKoro.Application.v1.CardEffects.Landmarks.Basic
{
    public class AmusementPark : ILandmarkEffect
    {
        public void Effect(Domain.Models.Game.Game game, Domain.Models.Player.Player player)
        {
            //TODO if throw double with dice take an extra turn

            if(game.Dices.IsSame())
            {

            }
        }
    }
}