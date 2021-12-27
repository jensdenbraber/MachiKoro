using MachiKoro.Domain.Models.Game;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Interfaces
{
    public interface IStepsRepository
    {
        Task<bool> AddStepAsync(Domain.Models.Game.Game game, Step step);
    }
}