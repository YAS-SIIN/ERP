using Microsoft.AspNetCore.SignalR;

namespace ERP.Api.HubServices
{
    public class TestHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReciveMessage", user, message);
        }
       
        // Summary:
        //     Called when a new connection is established with the hub.
        //
        // Returns:
        //     A System.Threading.Tasks.Task that represents the asynchronous connect.
        public override Task OnConnectedAsync()
        {
            var conectionId = Context.ConnectionId;
          return  base.OnConnectedAsync();
        }

        /// <summary>
        /// Called when a connection with the hub is terminated.
        /// </summary>
        /// <returns>A <see cref="Task"/> that represents the asynchronous disconnect.</returns>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
