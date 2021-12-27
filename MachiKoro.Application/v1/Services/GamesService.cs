using MachiKoro.Application.v1.Dice;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Game;
using System;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Services
{
    public class GamesService
    {
        private readonly IGamesRepository _gameRepository;
        private readonly IStepsRepository _stepRepository;

        public GamesService(IGamesRepository gameRepository, IStepsRepository stepRepository)
        {
            _gameRepository = gameRepository;
            _stepRepository = stepRepository;
        }

        public async Task PostActionDiceAmountAsync(Domain.Models.Game.Game game, object chosenResult)
        {
            var amountDice = Convert.ToInt32(chosenResult);
            var diceAmount = new Domain.Models.Dice.Dice().Roll(amountDice);

            var step = new Step
            {
                PlayerId = game.ActivePlayer.Id,
                StepKind = StepKind.Action,
                Type = (int)ActionType.DiceThrow,
                Result = diceAmount.ToArray()
            };

            await _stepRepository.AddStepAsync(game, step);
            // TODO send diceRoll to GameHub for client notification

            //TODO Earnincome()
        }

        public async Task EarnIncomeAsync(Domain.Models.Game.Game game)
        {
        }

        public async Task StartConstutionPhaseAsync(Domain.Models.Game.Game game)
        {
            //TODO GetConstructionOptions

            if (optionsAvailible)
            {
                // TODO send to GameHub option for player
                return;
            }

            await ToNextPlayerAsync(game);
        }

        public async Task Construction(Domain.Models.Game.Game game)
        {
        }

        public async Task ToNextPlayerAsync(Domain.Models.Game.Game game)
        {
            // TODO change player to next player
            // TODO check dice options

            if (hasDiceOptions)
            {
                // TODO send to GameHub option for player
                return;
            }

            await PostActionDiceAmountAsync(game, 1);
        }
    }
}