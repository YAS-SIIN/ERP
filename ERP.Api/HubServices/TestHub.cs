using Microsoft.AspNetCore.SignalR;

namespace ERP.Api.HubServices
{
    public class TestHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReciveMessage", user, message);
        }
        //
        // Summary:
        //     Called when a new connection is established with the hub.
        //
        // Returns:
        //     A System.Threading.Tasks.Task that represents the asynchronous connect.
        public override Task OnConnectedAsync()
        {
          return  base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);

        }
    }
}
