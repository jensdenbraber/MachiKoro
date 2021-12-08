using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Core.Models.DeleteGame
{
    public class DeleteGameRequest : IRequest<DeleteGameResponse>
    {
        [Required]
        public Guid GameId {get;set;}
    }
}
