using System.Threading;

namespace MachiKoro.Domain.Interfaces;

public interface IEstablishmentEffect
{
    public void Activate(Models.Game.Game game, Models.Player.Player player, CancellationToken cancellationToken);
}