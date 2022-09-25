using MediatR;
using System;

namespace MachiKoro.Application.v1.Game.Commands.Choose;

public class ChooseRequest : IRequest<ChooseResponse>
{
    public int Index { get; set; }
    public Guid GameId { get; set; }
    public Guid PlayerId { get; set; }
}