using ChatEkoSystem.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatEkoSystem.Hubs
{
    public class MyHub:Hub<IMessageClients>
    {
        static List<string> clients = new List<string>();
      public async Task SendMessageAsync(string message)
        {
        // await Clients.All.SendAsync("receiveMessage", message);
        }
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);
            
  

        }
        public override async Task  OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
    }
}
