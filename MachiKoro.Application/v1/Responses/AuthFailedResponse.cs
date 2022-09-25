using System.Collections.Generic;

namespace MachiKoro.Application.v1.Responses;

public record AuthFailedResponse
{
    public IEnumerable<string> Errors { get; init; }
}