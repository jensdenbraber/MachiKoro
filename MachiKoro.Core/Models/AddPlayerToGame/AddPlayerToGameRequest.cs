using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Core.Models.AddPlayerToGame
{
    public class AddPlayerToGameRequest : IRequest<AddPlayerToGameResponse>
    {
        [Required]
        public Guid PlayerId { get; set; }
        [Required]
        public Guid GameId { get; set; }
    }
}
