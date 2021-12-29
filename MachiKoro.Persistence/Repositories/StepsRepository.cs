using AutoMapper;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MachiKoro.Persistence.Repositories
{
    public class StepsRepository : IStepsRepository
    {
        private readonly IMapper _mapper;
        private readonly GameDataContext _gameDataContext;

        public StepsRepository(IMapper mapper, GameDataContext gameDataContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _gameDataContext = gameDataContext ?? throw new ArgumentNullException(nameof(gameDataContext));
        }

        public async Task<bool> AddStepAsync(Domain.Models.Game.Game game, Domain.Models.Game.Step step)
        {
            var stepData = _mapper.Map<Step>(step);

            stepData.StepIndex = await _gameDataContext.Steps.Where(x => x.GameId == game.Id).CountAsync();
            stepData.GameId = game.Id;

            await _gameDataContext.Steps.AddAsync(stepData);

            var added = await _gameDataContext.SaveChangesAsync();
            return added > 0;
        }
    }
}