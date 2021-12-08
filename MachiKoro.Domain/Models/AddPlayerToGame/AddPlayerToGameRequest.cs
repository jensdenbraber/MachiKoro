using MediatR;
using System;

namespace MachiKoro.Core.Models.AddPlayerToGame
{
    public class AddPlayerToGameRequest : IRequest<AddPlayerToGameResponse>
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
    }
}
