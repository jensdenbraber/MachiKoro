using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Core.Models.RemovePlayerFromGame
{
    public class RemovePlayerFromGameRequest : IRequest<RemovePlayerFromGameResponse>
    {
        [Required]
        public Guid PlayerId { get; set; }
        [Required]
        public Guid GameId { get; set; }
    }
}
