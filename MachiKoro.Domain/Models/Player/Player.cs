using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Core.Models.Player
{
    public class Player
    {
        public Guid Id { get; set; }
        public PlayerType PlayerType { get; set; }
        public int GoldAmount { get; set; }
    }
}
