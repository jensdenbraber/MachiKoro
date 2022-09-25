using MediatR;
using System;

namespace MachiKoro.Application.v1.Game.Queries.GetGame;

public class GetGameRequest : IRequest<GetGameResponse>
{
    public Guid GameId { get; set; }
}