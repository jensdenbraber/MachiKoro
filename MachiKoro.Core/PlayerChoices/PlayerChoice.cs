using System.Collections.Generic;

namespace MachiKoro.Core
{
    public class PlayerChoice
    {
        private readonly IPlayerOption _option;
        private readonly List<IPlayerOption> _options = new List<IPlayerOption>();
        
        public PlayerChoice(IPlayerOption option)
        {
            _option = option;
        }

        public PlayerChoice(List<IPlayerOption> options)
        {
            _options = options;
        }
    }
}
