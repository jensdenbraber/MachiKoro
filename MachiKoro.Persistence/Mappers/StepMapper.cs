using MachiKoro.Persistence.Models;

namespace MachiKoro.Persistence.Mappers;

public static class StepMapper
{
    public static Step ToPersistence(this Domain.Models.Game.Step step)
    {
        return new Step
        {
            PlayerId = step.PlayerId,
            Result = step.Result.ToString(),
        };
    }
}