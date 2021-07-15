using MachiKoro.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachiKoro.Api.DomainModels.CreateGame
{
    public class CreateGameRequest
    {
        public int MaxNumberOfPlayers { get; set; }
        public ExpensionType ExpensionType { get; set; }
    }
}
