using MachiKoro.Application.v1.Dice;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Cards;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using MachiKoro.Domain.Models.Cards.Landmarks.Basic;
using MachiKoro.Domain.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Services
{
    public class GamesService
    {
        private readonly IStepsRepository _stepRepository;
        private readonly INotifyPlayerService _playerService;

        public GamesService(IStepsRepository stepRepository, INotifyPlayerService playerService)
        {
            _stepRepository = stepRepository ?? throw new ArgumentNullException(nameof(stepRepository));
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        public async Task PostActionDiceAmountAsync(Domain.Models.Game.Game game, object chosenResult, CancellationToken cancellationToken)
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

            var stepAdded = await _stepRepository.AddStepAsync(game, step, cancellationToken);

            // TODO send diceRoll to GameHub for client notification
            await _playerService.SendNotificationDiceRollAsync(diceAmount, cancellationToken);

            //TODO Earnincome()
            await EarnIncomeAsync(game, cancellationToken);
        }

        public async Task EarnIncomeAsync(Domain.Models.Game.Game game, CancellationToken cancellationToken)
        {
            foreach (var player in game.Players)
            {
                foreach (var card in player.EstablishmentCards)
                {
                    card.ExecuteEffect(game, player, cancellationToken);
                }
            }

            var step = new Step
            {
                PlayerId = game.ActivePlayer.Id,
                StepKind = StepKind.Action,
                Type = (int)ActionType.EarnIncome,
                Result = game.Players.ToArray()
            };

            var stepAdded = await _stepRepository.AddStepAsync(game, step, cancellationToken);
        }

        public async Task StartConstructionPhaseAsync(Domain.Models.Game.Game game, CancellationToken cancellationToken)
        {
            var constructionEstablishmentsOptions = GetConstructionEstablishmentsOptions(game);
            var constructionLandmarksOptions = GetConstructionLandmarksOptions(game);

            if (constructionEstablishmentsOptions.Any() || constructionLandmarksOptions.Any())
            {
                // TODO send to GameHub option for player
                await _playerService.SendNotificationConstructionEstablishmentsOptionsAsync(game.ActivePlayer.Id, constructionEstablishmentsOptions, cancellationToken);
                await _playerService.SendNotificationConstructionLandmarksOptionsAsync(game.ActivePlayer.Id, constructionLandmarksOptions, cancellationToken);

                return;
            }

            await ToNextPlayerAsync(game, cancellationToken);
        }

        public async Task PostActionConstructionEstablishmentAsync(Domain.Models.Game.Game game, object chosenResult, CancellationToken cancellationToken)
        {
            var chosenIndex = Convert.ToInt32(chosenResult);

            var card = GetConstructionEstablishmentsOptions(game).ElementAt(chosenIndex);

            if (card is EstablishmentBase)
            {
                foreach (var cardDeck in game.CardDecks)
                {
                    var isRemoved = cardDeck.RevealedCards.Remove(card as EstablishmentBase);

                    if (isRemoved)
                    {
                        game.ActivePlayer.EstablishmentCards.Add(card as EstablishmentBase);
                    }
                }
            }

            var step = new Step
            {
                PlayerId = game.ActivePlayer.Id,
                StepKind = StepKind.Action,
                Type = (int)ActionType.Construction,
                Result = card
            };

            var stepAdded = await _stepRepository.AddStepAsync(game, step, cancellationToken);
        }

        public async Task PostActionConstructionLandmarkAsync(Domain.Models.Game.Game game, object chosenResult, CancellationToken cancellationToken)
        {
            var chosenIndex = Convert.ToInt32(chosenResult);

            var card = GetConstructionLandmarksOptions(game).ElementAt(chosenIndex);

            if (card is LandMark)
            {
                game.ActivePlayer.LandmarkCards.SingleOrDefault(x => x == card as LandMark).Construct();

                if (HasPlayerWon(game.ActivePlayer))
                {
                    await _playerService.SendNotificationWinnerAsync(game.ActivePlayer.Id, cancellationToken);
                }
            }

            var step = new Step
            {
                PlayerId = game.ActivePlayer.Id,
                StepKind = StepKind.Action,
                Type = (int)ActionType.Construction,
                Result = card
            };

            var stepAdded = await _stepRepository.AddStepAsync(game, step, cancellationToken);
        }

        private IEnumerable<Card> GetConstructionEstablishmentsOptions(Domain.Models.Game.Game game)
        {
            return game.CardDecks.SelectMany(cardDeck => cardDeck.RevealedCards.Where(establishment => establishment.ConstructionCost <= game.ActivePlayer.CoinAmount)).Cast<Card>();
        }

        private IEnumerable<Card> GetConstructionLandmarksOptions(Domain.Models.Game.Game game)
        {
            return game.ActivePlayer.LandmarkCards.Where(landmark => landmark.CompletionCost <= game.ActivePlayer.CoinAmount).Cast<Card>();
        }

        private async Task ToNextPlayerAsync(Domain.Models.Game.Game game, CancellationToken cancellationToken)
        {
            // TODO change player to next player
            var nextPlayer = game.Players.MoveNext;

            // TODO check dice options
            var hasDiceOptions = HasDiceoptions(nextPlayer);

            if (hasDiceOptions)
            {
                // TODO send to GameHub option for player
                return;
            }

            await PostActionDiceAmountAsync(game, 1, cancellationToken);
        }

        private bool HasDiceoptions(Domain.Models.Player.Player player)
        {
            return player.LandmarkCards.Exists(x => x.Name == "TrainStation" && x.IsConstructed);
        }

        private bool HasPlayerWon(Domain.Models.Player.Player player)
        {
            return player.LandmarkCards.All(x => x.IsConstructed);
        }
    }
}