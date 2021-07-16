using ChatEkoSystem.Data;
using ChatEkoSystem.Data.UnitOfWork;
using ChatEkoSystem.Model;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Hubs
{
    public class MessageHub:Hub
    {

        private IUnitOfWork _unitOfWork;
        public MessageHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Client GetClient(string nickName) 
        {
            Client client = new Client
            {
                ConnectionId = Context.ConnectionId,
                NickName = nickName,
                TimeStampBegin = DateTime.Now
                
            };
            ClientSource.Clients.Add(client);
            return client;
        }
        public async Task GetNickName(string nickName)
        {
            
            _unitOfWork.GetRepository<Client>().Add(GetClient(nickName));
            await Clients.Others.SendAsync("clientJoined",nickName);
            await Clients.All.SendAsync("clients",ClientSource.Clients);
        }
        public async Task SendMessageAsync(string message, string clientName)
        {
            if(clientName== "All")
            {
                await Clients.All.SendAsync("receiveMassage",message);
            }
            else
            {
                Client client = ClientSource.Clients.FirstOrDefault(x => x.NickName == clientName);
                await Clients.Client(client.ConnectionId).SendAsync("receiveMessage",message);
            }
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
        public async Task addGroup(string connectionId,string groupName)
        {
            await Groups.AddToGroupAsync(connectionId,groupName);
        }
       
    }
}
