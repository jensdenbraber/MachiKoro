using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs;

public class GameLobbyHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    //public async Task<IActionResult> GetAllAsync()
    //{
    //    List<Game> games = await _gameService.GetAllGamesAsync();

    //    return Ok(_mapper.Map<GameResponse>(games));
    //}
}