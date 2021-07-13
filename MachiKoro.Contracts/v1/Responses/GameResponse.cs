using System;
using System.Collections.Generic;

namespace MachiKoro.Contracts.v1.Responses
{
    public class GameResponse
    {
        public Guid Id { get; set; }
        public Guid ActivePlayerId { get; set; }
        public IEnumerable<PlayerResponse> Players { get; set; }

        //public IEnumerable<PlayerInventoryResponse> PlayerInventory { get; set; }

        //public CardDeckResponse CardDeck { get; set; }

        


    }
}
