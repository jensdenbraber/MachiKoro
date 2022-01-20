using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;
using System;
using System.Threading.Tasks;

namespace MachiKoro.Api.Hubs
{
    [SignalRHub(path: "/hubs/GameHub")]
    public class GameHub : Hub<Application.v1.Interfaces.INotifyPlayerService>
    {
        [SignalRMethod(name: "SendMessage", Microsoft.OpenApi.Models.OperationType.Post)]
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendNotificationWinnerAsync(new Guid());
        }

        [SignalRMethod(name: "Choice", Microsoft.OpenApi.Models.OperationType.Post)]
        public async Task Choice(string choice)
        {
            // TODO parse choice json to object
        }

        //[SignalRMethod(name: "nameOfTheMethodCalledOnTheClientSide", Microsoft.OpenApi.Models.OperationType.Post)]
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        //[SignalRMethod(name: "RollDice", Microsoft.OpenApi.Models.OperationType.Post)]
        //public async Task RollDice(string user)
        //{
        //    int diceValue = 12;

        //    await Clients.All.SendAsync("DiceRoll", user, diceValue);
        //}

        //[HttpPost(ApiRoutes.Games.Upkeep)]
        //[Consumes("application/json")]
        //public async Task<IActionResult> PlayerUpkeep([FromRoute] Guid gameId, [FromRoute] Guid playerId)
        //{
        //    // execute the players upkeep

        //    throw new NotImplementedException();
        //}

        //[HttpPost(ApiRoutes.Games.RollDice)]
        //[Consumes("application/json")]
        //public async Task<IActionResult> PlayerRollDice([FromRoute] Guid gameId, [FromRoute] Guid playerId)//, DiceOptionsRequest diceOptions)
        //{
        //    throw new NotImplementedException();
        //}
    }
}