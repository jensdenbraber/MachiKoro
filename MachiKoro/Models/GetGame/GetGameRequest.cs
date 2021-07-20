using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Api.Models.GetGame
{
    public class GetGameRequest
    {
        [Required]
        public Guid GameId { get; set; }
    }
}
