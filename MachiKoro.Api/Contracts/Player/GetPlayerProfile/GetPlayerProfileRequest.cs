using System;

namespace MachiKoro.Api.Contracts.Player.GetPlayerProfile
{
    public class GetPlayerProfileRequest
    {
        public Guid PlayerId { get; set; }
    }
}