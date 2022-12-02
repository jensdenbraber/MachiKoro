using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Persistence.Data;
using MachiKoro.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Persistence.Repositories;

public class StepsRepository : IStepsRepository
{
    private readonly GameDataContext _gameDataContext;

    public StepsRepository(GameDataContext gameDataContext)
    {
        _gameDataContext = gameDataContext ?? throw new ArgumentNullException(nameof(gameDataContext));
    }

    public async Task<bool> AddStepAsync(Domain.Models.Game.Game game, Domain.Models.Game.Step step, CancellationToken cancellationToken)
    {
        var stepData = step.ToPersistence();

        stepData.StepIndex = await _gameDataContext.Steps.Where(x => x.GameId == game.Id).CountAsync(cancellationToken: cancellationToken);
        stepData.GameId = game.Id;

        await _gameDataContext.Steps.AddAsync(stepData, cancellationToken);

        var added = await _gameDataContext.SaveChangesAsync(cancellationToken);
        return added > 0;
    }
}