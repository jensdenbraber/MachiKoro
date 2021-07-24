using MediatR;
using System;

namespace MachiKoro.Core.Models.GetGame
{
    public class GetGameRequest : IRequest<GetGameResponse>
    {
        public Guid GameId { get; set; }
    }
}
