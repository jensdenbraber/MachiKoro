using System.Collections.Generic;

namespace MachiKoro.Contracts.v1.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
