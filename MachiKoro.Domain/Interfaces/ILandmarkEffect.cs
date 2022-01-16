using System.Threading;

namespace MachiKoro.Domain.Interfaces
{
    public interface ILandmarkEffect
    {
        public void Effect(Models.Game.Game game, Models.Player.Player player, CancellationToken cancellationToken);
    }
}