using System.Collections.Generic;

namespace MachiKoro.Contracts.v1.Responses
{
    public class GameFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}