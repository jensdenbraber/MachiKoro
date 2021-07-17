using MachiKoro.Core.CardDecks;
using MachiKoro.Core.Interfaces;
using MachiKoro.Core.Players;
using MachiKoro.Core.Players.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MachiKoro.Core.Game
{
    public class Game : IGame
    {
        public int NumberOfTurns { get; private set; }
        public int NumberOfOrbits { get; private set; }
        public readonly List<CardDeck> CardDecks;
        private readonly List<Dice.Dice> _dices = new List<Dice.Dice>();
        private Player InitialActivePlayer { get; }
        public Player ActivePlayer { get; set; }

        public Queue<Player> Players { get; internal set; }
        public Guid Id { get; set; }

        private List<Player> PlayersList = new List<Player>();

        public Game(List<CardDeck> cardDecks)
        {
            Players = new Queue<Player>();
            CardDecks = cardDecks;
            ActivePlayer = Players.Peek();
            InitialActivePlayer = Players.Peek();
        }

        public void AddPlayer(Player player)
        {
            PlayersList.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            PlayersList.Remove(player);
        }


        public Game(Queue<Player> players, List<CardDeck> cardDecks, List<Dice.Dice> dices)
        {
            Players = new Queue<Player>(players);
            CardDecks = cardDecks;
            ActivePlayer = Players.Peek();
            InitialActivePlayer = Players.Peek();
        }

        public Game(List<Player> players, List<CardDeck> cardDecks, List<Dice.Dice> dices)
        {
            foreach (var player in players)
            {
                Players.Enqueue(new Player(player.Id, player.PlayerType, this, player.GoldAmount, player.EstablishmentCards, player.LandmarkCards));
            }

            CardDecks = cardDecks;
            ActivePlayer = Players.Peek();
            InitialActivePlayer = Players.Peek();
        }


        //public bool PlayerJoin(Player player)
        //{
        //    Players.Enqueue(new Player(player.Id, player.PlayerType, this, player.GoldAmount, player.EstablishmentCards, player.LandmarkCards));
        //}

        //public bool PlayerLeave(Player player)
        //{
        //    if (!Players.Contains(player))
        //        return false;

        //    Stack<Player> qwe = new Stack<Player>();
        //    qwe.

        //    Players.
        //    return Players.TryDequeue(out player);
        //}

        public void AnalyseTheTurn()
        {
            //ActivePlayer.
        }

        public List<PlayerChoice> PlayerUpkeep()
        {
            var playerUpkeepEventArgs = new PlayerUpkeepEventArgs();
            
            ActivePlayer.PlayerUpkeep(this, playerUpkeepEventArgs);

            return playerUpkeepEventArgs.PlayerChoices;
        }

        internal void Start()
        {
            throw new NotImplementedException();
        }

        public List<PlayerChoice> PlayerPostDieRoll()
        {
            var playerPostDieRollEventArgs = new PlayerPostDieRollEventArgs();

            ActivePlayer.PlayerPostDieRoll(this, playerPostDieRollEventArgs);

            return playerPostDieRollEventArgs.PlayerChoices;
        }

        public List<PlayerChoice> PlayerMainPhase()
        {
            var playerMainPhaseEventArgs = new PlayerMainPhaseEventArgs();

            ActivePlayer.PlayerMainPhase(this, playerMainPhaseEventArgs);

            return playerMainPhaseEventArgs.PlayerChoices;
        }

        public void PlayerUpkeepAction(List<PlayerAction> playerActions)
        {
            playerActions.ForEach(x => x.Execute());
        }

        public IEnumerable<Player> Opponents()
        {
            return Players.Skip(1);
        }

        public void StartTheTurn(int diceNumber)
        {
            foreach (var player in Players)
            {
                foreach (var establishment in player.EstablishmentCards)
                {
                    if(establishment.ActivationNumbers.Contains(diceNumber))
                    {
                        establishment.Activate(this);
                    }
                }
            }
        }



        //public PlayerActions ValidPlayerActions(Player player)
        //{
        //    List<EstablishmentBase> validToBuyEstablishments = new List<EstablishmentBase>();

        //    foreach (var cardDeck in CardDecks)
        //    {
        //        foreach (var revealedCard in cardDeck.RevealedCards)
        //        {
        //            if(player.GoldAmount >= revealedCard.ConstructionCost)
        //            {
        //                validToBuyEstablishments.Add(revealedCard);
        //            }
        //        }
        //    }

        //    return validToBuyEstablishments;
        //}



        public Player EndStep()
        {
            return IsWinner();
        }


        public void EndTheTurn()
        {
            IsWinner();

            if (!Players.TryDequeue(out Player player))
                throw new Exception();

            ActivePlayer = player;
            Players.Enqueue(player);

            NumberOfTurns++;

            if(InitialActivePlayer == ActivePlayer)
                NumberOfOrbits++;
        }

        private Player IsWinner()
        {
            return ActivePlayer.LandmarkCards.All(x => x.IsConstructed) ? ActivePlayer : null;
        }
    }
}
