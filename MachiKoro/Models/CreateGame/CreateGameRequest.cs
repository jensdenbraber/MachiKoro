using MachiKoro.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachiKoro.Api.Models.CreateGame
{
    public class CreateGameRequest
    {
        public int MaxNumberOfPlayers { get; set; }
        public ExpensionType ExpensionType { get; set; }
    }
}
