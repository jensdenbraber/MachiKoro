using MachiKoro.Domain.Enums;
using MediatR;
using System;

namespace MachiKoro.Application.v1.Game.Commands.CreateGame;

public class CreateGameCommand : IRequest<CreateGameResponse>
{
    public Guid PlayerId { get; set; }
    public int MaxNumberOfPlayers { get; set; }
    public ExpensionType ExpensionType { get; set; }
}