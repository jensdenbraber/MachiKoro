using MachiKoro.Domain.Models.Game;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Domain.Interfaces;

public interface IStepsRepository
{
    Task<bool> AddStepAsync(Game game, Step step, CancellationToken cancellationToken);
}