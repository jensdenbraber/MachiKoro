using MachiKoro.Application.v1.Dice;
using MachiKoro.Application.v1.Game.Commands.Choices;
using MachiKoro.Application.v1.Interfaces;
using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Models.Cards.Establishments.Basic;
using MachiKoro.Domain.Models.Cards.Landmarks.Basic;
using MachiKoro.Domain.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MachiKoro.Application.v1.Services
{
    public class GamesService
    {
        private readonly IStepsRepository _stepRepository;
        private readonly INotifyPlayerService _playerService;
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IStepsRepository stepRepository, INotifyPlayerService playerService, IGamesRepository gamesRepository)
        {
            _stepRepository = stepRepository ?? throw new ArgumentNullException(nameof(stepRepository));
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            _gamesRepository = gamesRepository ?? throw new ArgumentNullException(nameof(gamesRepository));
        }

        public async Task AnalizeChoiceAsync(Guid gameId, string data, CancellationToken cancellationToken)
        {
            var choice = JsonSerializer.Deserialize<Choice>(data);

            switch (choice.ChoiceType)
            {
                case ChoiceType.AmountDices:
                    {
                        var diceAmountChoice = JsonSerializer.Deserialize<DiceAmountChoice>(data);

                        await PostActionDiceAmountAsync(gameId, diceAmountChoice, cancellationToken);
                        break;
                    }

                case ChoiceType.ConstructEstablishment:
                    {
                        var buyChoice = JsonSerializer.Deserialize<BuyChoice>(data);

                        await PostActionConstructionEstablishmentAsync(gameId, buyChoice, cancellationToken);
                        break;
                    }

                case ChoiceType.ConstructLandmark:
                    {
                        var buyChoice = JsonSerializer.Deserialize<BuyChoice>(data);

                        await PostActionConstructionEstablishmentAsync(gameId, buyChoice, cancellationToken);
                        break;
                    }

                case ChoiceType.Swap:
                    {
                        var swapChoice = JsonSerializer.Deserialize<SwapChoice>(data);

                        await PostActionIncomeAsync(gameId, swapChoice, cancellationToken);
                        break;
                    }
            }
        }

        public async Task PreActionDiceAmountAsync(Domain.Models.Game.Game game, CancellationToken cancellationToken)
        {
            if (HasDiceoptions(game.ActivePlayer))
            {
                await _playerService.SendNotificationDiceAmountAsync(game.ActivePlayer.Id, cancellationToken);
            }
            else
            {
                await _playerService.SendNotificationDiceRollAsync(game.ActivePlayer.Id, cancellationToken);
            }
        }

        public async Task PostActionDiceAmountAsync(Guid gameId, DiceAmountChoice choice, CancellationToken cancellationToken)
        {
            var game = await _gamesRepository.GetGameAsync(gameId, cancellationToken);

            var diceAmount = new Domain.Models.Dice.Dice().Roll(choice.DiceAmount);

            var step = new Step
            {
                PlayerId = game.ActivePlayer.Id,
                StepKind = StepKind.Action,
                Type = (int)ActionType.DiceThrow,
                Result = diceAmount.ToArray()
            };

            var stepAdded = await _stepRepository.AddStepAsync(game, step, cancellationToken);

            await _playerService.SendNotificationDiceRollAsync(diceAmount, cancellationToken);

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

            await StartConstructionPhaseAsync(game, cancellationToken);
        }

        private async Task PostActionIncomeAsync(Guid gameId, SwapChoice choice, CancellationToken cancellationToken)
        {
            var game = await _gamesRepository.GetGameAsync(gameId, cancellationToken);

            foreach (var player in game.Opponents)
            {
                var targetB = player.EstablishmentCards.SingleOrDefault(c => c.Id.Equals(choice.TargetBCardId));

                if (targetB != null)
                {
                    var targetA = game.ActivePlayer.EstablishmentCards.SingleOrDefault(c => c.Id.Equals(choice.TargetACardId));

                    if (targetA != null)
                    {
                        player.EstablishmentCards.Remove(targetB);
                        player.EstablishmentCards.Add(targetA);

                        game.ActivePlayer.EstablishmentCards.Remove(targetA);
                        game.ActivePlayer.EstablishmentCards.Add(targetB);
                    }
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

        private async Task StartConstructionPhaseAsync(Domain.Models.Game.Game game, CancellationToken cancellationToken)
        {
            var constructionEstablishmentsOptions = GetConstructionEstablishmentsOptions<EstablishmentBase>(game);
            var constructionLandmarksOptions = GetConstructionLandmarksOptions(game);

            if (constructionEstablishmentsOptions.Any() || constructionLandmarksOptions.Any())
            {
                await _playerService.SendNotificationConstructionEstablishmentsOptionsAsync(game.ActivePlayer.Id, constructionEstablishmentsOptions, cancellationToken);
                await _playerService.SendNotificationConstructionLandmarksOptionsAsync(game.ActivePlayer.Id, constructionLandmarksOptions, cancellationToken);
            }
        }

        public async Task PostActionConstructionEstablishmentAsync(Guid gameId, BuyChoice buyChoice, CancellationToken cancellationToken)
        {
            var game = await _gamesRepository.GetGameAsync(gameId, cancellationToken);

            var card = GetConstructionEstablishmentsOptions<EstablishmentBase>(game).SingleOrDefault(x => x.Id == buyChoice.CardId);

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

            await ToNextPlayerAsync(game, cancellationToken);
        }

        public async Task PostActionConstructionLandmarkAsync(Domain.Models.Game.Game game, BuyChoice buyChoice, CancellationToken cancellationToken)
        {
            var card = GetConstructionLandmarksOptions(game).SingleOrDefault(x => x.Id == buyChoice.CardId);

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

            await ToNextPlayerAsync(game, cancellationToken);
        }

        private IEnumerable<T> GetConstructionEstablishmentsOptions<T>(Domain.Models.Game.Game game)
        {
            return game.CardDecks.SelectMany(cardDeck => cardDeck.RevealedCards.Where(establishment => establishment.ConstructionCost <= game.ActivePlayer.CoinAmount)).Cast<T>();
        }

        private IEnumerable<LandMark> GetConstructionLandmarksOptions(Domain.Models.Game.Game game)
        {
            return game.ActivePlayer.LandmarkCards.Where(landmark => landmark.CompletionCost <= game.ActivePlayer.CoinAmount);
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

            await PreActionDiceAmountAsync(game, cancellationToken);
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